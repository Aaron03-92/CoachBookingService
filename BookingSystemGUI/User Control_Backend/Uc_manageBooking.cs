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

namespace BookingSystemGUI.User_Control_Backend
{ 
    public partial class Uc_manageBooking : UserControl
    {
        SqlCommand cmd;
        int bookingId, CoachId;
        private static IsqlDataFunctions _IsqlDataFunctions;

        public Uc_manageBooking(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_manageBooking(sqlDataFunctions);
        }
        public Uc_manageBooking()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
            button2.Enabled = false;
        }

        private void Uc_manageBooking_Load(object sender, EventArgs e)
        {
            LoadBookings();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bookingId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSeatNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTicketType.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDateOfPurchase.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDepart.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDestination.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();                                        
            txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDateOfDeparture.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            CoachId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
            button2.Enabled = true;
            DisablingTextBoxes();
        }
        private void DisablingTextBoxes() 
        {            
            txtDepart.Enabled = false;
            txtDestination.Enabled = false;
            txtDateOfPurchase.Enabled = false;
            txtSeatNo.Enabled = false;
            txtTicketType.Enabled = false;
            txtPrice.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtDateOfDeparture.Enabled = false;
        }
        private void clearFields() 
        {            
            txtDepart.Text = "";
            txtDestination.Text = "";
            txtDateOfPurchase.Text = "";
            txtSeatNo.Text = "";
            txtTicketType.Text = "";
            txtPrice.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDateOfDeparture.Text = "";
        }

        private void searchBookingIdBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbookingId.Text)) 
            {
                MessageBox.Show("Error: please ensure you have entered an Id within the field provided!");
            }
            else 
            {
                string query = "SELECT b.bookingId, b.seatNo, b.ticketType, p.amount, p.dateOfPurchase, cs.stationDeparture, cs.stationArrival, cs.dateOfDeparture, c.firstName, c.lastName, co.CoachId FROM Bookings b JOIN coachSchedule cs ON b.scheduleId = cs.coachScheduleId JOIN payment p ON p.bookingId = b.bookingId JOIN customer c ON b.customerId = c.customerId JOIN Coach co ON co.CoachId = cs.coachId WHERE b.bookingId= @bookingId";
                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@bookingId", txtbookingId.Text);

                _IsqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if(dataGridView1.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately the booking Id you have entered does not exist!");
                }
            }           
        }
        private void searchCustomerBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCustomerFirstName.Text)) 
            {
                MessageBox.Show("Error: please ensure you have entered a customers first name within the field provided!");
            }
            else 
            {
                string query = "SELECT b.bookingId, b.seatNo, b.ticketType, p.amount, p.dateOfPurchase, cs.stationDeparture, cs.stationArrival, cs.dateOfDeparture, c.firstName, c.lastName, co.CoachId FROM Bookings b JOIN coachSchedule cs ON b.scheduleId = cs.coachScheduleId JOIN payment p ON p.bookingId = b.bookingId JOIN customer c ON b.customerId = c.customerId JOIN Coach co ON co.CoachId = cs.coachId WHERE  c.firstName LIKE @name +'%' ";

                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@name", txtCustomerFirstName.Text);
                _IsqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if(dataGridView1.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately no bookings exist under the name you have entered!");
                }
            }            
        }
        private void LoadBookings ()
        {
          
            string query = "SELECT b.bookingId, b.seatNo, b.ticketType, p.amount, p.dateOfPurchase, cs.stationDeparture, cs.stationArrival, cs.dateOfDeparture, c.firstName, c.lastName, co.CoachId FROM Bookings b JOIN coachSchedule cs ON b.scheduleId = cs.coachScheduleId JOIN payment p ON p.bookingId = b.bookingId JOIN customer c ON b.customerId = c.customerId JOIN Coach co ON co.CoachId = cs.coachId";
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }
           
        private void button2_Click(object sender, EventArgs e)
        {

            string query_2 = "DELETE Bookings Where bookingId= @bookingId";
            string query_3 = "Update Coach SET numberOfSeats = numberOfSeats+1 WHERE CoachId = @coachId";/// need to test
           
            cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@bookingId", bookingId);
            _IsqlDataFunctions.ManagingData(cmd);

            cmd = new SqlCommand(query_3, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@coachId", CoachId);     
            _IsqlDataFunctions.ManagingData(cmd, "Booking has been deleted succesfully!");
            clearFields();
            button2.Enabled = false;
            LoadBookings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT b.bookingId, b.seatNo, b.ticketType, p.amount, p.dateOfPurchase, cs.stationDeparture, cs.stationArrival, cs.dateOfDeparture, c.firstName, c.lastName, co.CoachId FROM Bookings b JOIN coachSchedule cs ON b.scheduleId = cs.coachScheduleId JOIN payment p ON p.bookingId = b.bookingId JOIN customer c ON b.customerId = c.customerId JOIN Coach co ON co.CoachId = cs.coachId ORDER BY b.bookingId";
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT b.bookingId, b.seatNo, b.ticketType, p.amount, p.dateOfPurchase, cs.stationDeparture, cs.stationArrival, cs.dateOfDeparture, c.firstName, c.lastName, co.CoachId FROM Bookings b JOIN coachSchedule cs ON b.scheduleId = cs.coachScheduleId JOIN payment p ON p.bookingId = b.bookingId JOIN customer c ON b.customerId = c.customerId JOIN Coach co ON co.CoachId = cs.coachId ORDER BY b.bookingId DESC";         
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void searchLastNameBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerLastName.Text))
            {
                MessageBox.Show("Error: please ensure you have entered a customers last name within the field provided!");
            }
            else
            {
                string query = "SELECT b.bookingId, b.seatNo, b.ticketType, p.amount, p.dateOfPurchase, cs.stationDeparture, cs.stationArrival, cs.dateOfDeparture, c.firstName, c.lastName, co.CoachId FROM Bookings b JOIN coachSchedule cs ON b.scheduleId = cs.coachScheduleId JOIN payment p ON p.bookingId = b.bookingId JOIN customer c ON b.customerId = c.customerId JOIN Coach co ON co.CoachId = cs.coachId WHERE  c.lastName LIKE @name +'%' ";

                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@name", txtCustomerFirstName.Text);
                _IsqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Unfortunately no bookings exist under the name you have entered!");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserControlFeatures.ExportDataToExcel(dataGridView1);
        }
    }
}
