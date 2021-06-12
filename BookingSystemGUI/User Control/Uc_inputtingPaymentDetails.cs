using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookingSystemGUI.User_Control
{
    public partial class Uc_inputtingPaymentDetails : UserControl
    {

        SqlCommand cmd;
        public string CoachId { get; set; }
        public string Price { get; set; }
        public string ScheduleId { get; set; }
        private static IsqlDataFunctions _IsqlDataFunctions;

        public Uc_inputtingPaymentDetails(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_inputtingPaymentDetails(sqlDataFunctions);
        }
        public Uc_inputtingPaymentDetails()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
            TimepickerFormat();
        }
        private void Uc_inputtingPaymentDetails_Load(object sender, EventArgs e)
        {
            LoadingCreditCardDetails();
        }
        private void TimepickerFormat()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void buyTicketBtn_Click(object sender, EventArgs e)
        {

            string query_1 = "INSERT into bankCard (cardType, cardNumber, nameOnCard, expiryDate, customerId) VALUES ( @cardType, @cardNo, @cardName, @date, @customerId)";
            string query_2 = "INSERT into payment (amount, dateOfPurchase, bookingId, bankCardId) VALUES (@amount, @dateOfPurchase, @bookingId, @cardId)";

            if (comboBoxCardType.Text == "" || txtCardNumber.Text == "" || txtNameOnCard.Text == "" || txtSecurityCode.Text == "")
            {
                MessageBox.Show("Please ensure that all fields have been filled!");
            }
            else if (txtCardNumber.Text.IsNumeric() || txtCardNumber.Text.Length != 16)
            {
                MessageBox.Show("Please ensure that your card number is 16 digits long and in the correct format!");
            }
            else if (txtSecurityCode.Text.IsNumeric() || txtSecurityCode.Text.Length != 3)
            {
                MessageBox.Show("Please ensure that your security number is 3 digits long and in the correct!");
            }
            else
            {
                cmd = new SqlCommand(query_1, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@cardType", comboBoxCardType.Text);
                cmd.Parameters.AddWithValue("@cardNo", txtCardNumber.Text);
                cmd.Parameters.AddWithValue("@cardName", txtNameOnCard.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());                
                _IsqlDataFunctions.ManagingData(cmd);

                cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@amount", Price);
                cmd.Parameters.AddWithValue("@dateOfPurchase", dateOfPurchase.Value);
                cmd.Parameters.AddWithValue("@bookingId", GetBookingId());
                cmd.Parameters.AddWithValue("@cardId", _IsqlDataFunctions.GetBankCardId());
                _IsqlDataFunctions.ManagingData(cmd, "Payment succesful. Thank you for using Triple G coach services!\n We hope that you have a pleasant journey\nA confirmation email will be sent to you very shortly");

                GUIFunctionality.RevealForm(new Uc_inputtingPaymentDetails(), new Dashboard());

            }
        }
        private void btnGoBack_Click(object sender, EventArgs e)
        {

            MessageBox.Show(CoachId);
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to navigate away from this page?", "Stop", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                string query_1 = "DELETE FROM Bookings WHERE bookingId = (SELECT MAX(BookingId) FROM Bookings)";
                cmd = new SqlCommand(query_1, _IsqlDataFunctions.GetConnection());

                _IsqlDataFunctions.ManagingData(query_1);

                string query_2 = "UPDATE Coach SET numberOfSeats = numberOfSeats+1 WHERE CoachId = @coachId";

                cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@coachId", CoachId);

                _IsqlDataFunctions.ManagingData(cmd);
                GUIFunctionality.ShowUserControl(paymentPanel, new Uc_addBooking());

            }
        }
        public void LoadingCreditCardDetails()
        {
            var cardDetails = new List<creditCard>();

            var getData = "SELECT * FROM bankCard WHERE customerId = @customerId AND cardId = (SELECT MAX(cardId) from bankCard)";
            SqlCommand cmd = new SqlCommand(getData, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());

            _IsqlDataFunctions.GetConnection().Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cardDetails.Add(new creditCard()
                {
                    Id = reader.GetInt32(0),
                    CardType = reader.GetString(1),
                    CardNumber = reader.GetInt64(2),
                    NameOnCard = reader.GetString(3),
                    ExpiryDate = reader.GetString(4),
                    CustomerID = reader.GetInt32(5)
                });
            }
            foreach (var i in cardDetails)
            {
                if (i.CustomerID == SignIn.GetCustomerId())
                {
                    DialogResult dialogResult = MessageBox.Show($"we've noticed that you have made a booking with us before. Would you like to use the the bank details from your last purchase:\n\n{i.CardType}\n\n{i.CardNumber}\n\n{i.NameOnCard}\n\n{i.ExpiryDate}?", "Attention", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        comboBoxCardType.Text = i.CardType;
                        txtCardNumber.Text = i.CardNumber.ToString();
                        txtNameOnCard.Text = i.NameOnCard;
                        dateTimePicker1.Text = i.ExpiryDate;
                        _IsqlDataFunctions.GetConnection().Close();
                        break;
                    }
                }
            }
            _IsqlDataFunctions.GetConnection().Close();
        }
        public int GetBookingId()
        {

            int Id = 0;

            var getData = "SELECT MAX (bookingId) FROM Bookings WHERE customerId = @customerId";
            SqlCommand cmd = new SqlCommand(getData, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());


            _IsqlDataFunctions.GetConnection().Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Id = reader.GetInt32(0);
            }

            _IsqlDataFunctions.GetConnection().Close();
            return Id;
        }

    }
    public static class StringExtensions
    {
        public static bool IsNumeric(this string text) => (!double.TryParse(text, out _));

    }
}


