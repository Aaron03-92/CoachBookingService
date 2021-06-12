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
    public partial class Uc_bookingDetails : UserControl
    {

        SqlCommand cmd;
        int n = 0;
        Bitmap available = Properties.Resources.availableSeatt;
        Bitmap taken = Properties.Resources.provisional;
        Bitmap booked = Properties.Resources.seatTaken;
        private List<string> seatNumbers = new List<string>();
        private  List<seat> _seatPictureBoxes;
        private Uc_inputtingPaymentDetails _InputtingPaymentDetails;
        string selectedSeatNo;

        private static IsqlDataFunctions _IsqlDataFunctions;

        public Uc_bookingDetails(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_bookingDetails(sqlDataFunctions);
        }

        public Uc_bookingDetails()
        {
            InitializeComponent();          
            creationOfSqlDataFunctions();                             
            _InputtingPaymentDetails = new Uc_inputtingPaymentDetails();

        }
        public void PreparingSeatUI()
        {
            string GetDataQuery = "SELECT seatNo FROM Bookings where scheduleId = @scheduleId";

            cmd = new SqlCommand(GetDataQuery, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@scheduleId", txtSchedule.Text);

            _IsqlDataFunctions.GetConnection().Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                seatNumbers.Add(reader.GetInt32(0).ToString());
            }
            _IsqlDataFunctions.GetConnection().Close();
        

            _seatPictureBoxes = Controls.OfType<seat>().ToList();
            foreach (var seatPictureBox in _seatPictureBoxes)
            {
                seatPictureBox.Click += SeatPictureBoxOnClick;

               
                if (seatNumbers.Contains(seatPictureBox.Seat))
                {
                    seatPictureBox.Image = booked;
                    seatPictureBox.Enabled = false;                    
                    
                }
                else
                {
                    seatPictureBox.Image = available;
                }
            }                      
        }
    
        private void Uc_bookingDetails_Load(object sender, EventArgs e)
        {          
            LoadingDataintoFields();
            PreparingSeatUI();
        }
        private void LoadingDataintoFields()
        {
            txtDeparting.Text = confirmDetailsDataGrid.CurrentRow.Cells[0].Value.ToString();
            txtDestination.Text = confirmDetailsDataGrid.CurrentRow.Cells[1].Value.ToString();
            txtDepartureDate.Text = confirmDetailsDataGrid.CurrentRow.Cells[4].Value.ToString();
            txtPrice.Text = confirmDetailsDataGrid.CurrentRow.Cells[5].Value.ToString();
            txtCoachId.Text = confirmDetailsDataGrid.CurrentRow.Cells[6].Value.ToString();
            
        }
        private void SeatPictureBoxOnClick(object sender, EventArgs e)
        {
            var pb = (seat)sender;
            if (pb.Available)
            {
                pb.Image = taken; 
                pb.Available = false;
            }
            else
            {
                pb.Image = available; 
                pb.Available = true;
            }                              
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            var uc = new User_Control.Uc_addBooking();
            addBookingPanel.BringToFront();
            GUIFunctionality.ShowUserControl(addBookingPanel, uc);
                    
        }
         
        private void confirmBookingBtn_Click_1(object sender, EventArgs e)
        {
                    
            foreach (var seatPictureBox in _seatPictureBoxes)
            {
                if (seatPictureBox.Available == false)
                {
                    n++;
                    selectedSeatNo = $"{seatPictureBox.Row }{seatPictureBox.Number}";
                                       
                }
            }
            
            string query_1 = "UPDATE Coach set numberOfSeats = numberOfSeats-1 WHERE CoachId = @coachId "; 
            SqlCommand cmd1 = new SqlCommand(query_1, _IsqlDataFunctions.GetConnection());
            cmd1.Parameters.AddWithValue("@coachId", int.Parse(txtCoachId.Text));
            
            string query_2 = "Insert into Bookings (seatNo, ticketType, customerId, scheduleId)  VALUES ( @seatNo, @ticketType, @customerId, @scheduleId )";
          
            cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@seatNo", selectedSeatNo);
            cmd.Parameters.AddWithValue("@ticketType", txtTicketType.Text);
            cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());
            cmd.Parameters.AddWithValue("@scheduleId", txtSchedule.Text);


            if (n > 1 || selectedSeatNo == null)
            {
                MessageBox.Show("Please ensure one seat has been selected!");
            }
            if (n == 1) 
            {

                _IsqlDataFunctions.ManagingData(cmd1);
                _IsqlDataFunctions.ManagingData(cmd);
                _InputtingPaymentDetails.ScheduleId = txtSchedule.Text;
                _InputtingPaymentDetails.CoachId = txtCoachId.Text;
                _InputtingPaymentDetails.Price = txtPrice.Text;
                addBookingPanel.BringToFront();
                GUIFunctionality.ShowUserControl(addBookingPanel, _InputtingPaymentDetails);
       
            }      
        }       
    }
}


