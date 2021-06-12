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
    public partial class Uc_myBookings : UserControl
    {
        SqlCommand cmd;
        private static IsqlDataFunctions _IsqlDataFunctions;
        public Uc_myBookings(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_myBookings(sqlDataFunctions);
        }
        public Uc_myBookings()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
        }

        private void Uc_myBookings_Load(object sender, EventArgs e)
        {
            LoadUserBookings();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
    
            var bookingId = int.Parse(usersBookings.CurrentRow.Cells[0].Value.ToString());
            var coachId = int.Parse(usersBookings.CurrentRow.Cells[8].Value.ToString());

        
            string query_2 = "Delete Bookings Where bookingId = @bookingId";
            string query_3 = "Update Coach SET NumberOfSeats = NumberOfSeats+1 WHERE CoachId = @coachId";

            cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@bookingId", bookingId);
            _IsqlDataFunctions.ManagingData(cmd);

            cmd = new SqlCommand(query_3, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@coachId", coachId);
            _IsqlDataFunctions.ManagingData(cmd, "Booking has been deleted. Please note the refund of your booking will be transfered back into your account within the next 3 working days.");
                                     
            LoadUserBookings();
        }
        private void LoadUserBookings() 
        {
            string query = "Select b.bookingId, b.seatNo, b.ticketType, cs.stationDeparture, cs.stationArrival, cs.dateOfdeparture, cs.timeOfDeparture, cs.timeOfArrival, c.CoachId FROM Bookings b JOIN coachSchedule cs ON cs.coachScheduleId = b.scheduleId AND b.customerId= @customerId JOIN Coach c On c.CoachId = cs.coachId " ;

            cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());
            _IsqlDataFunctions.displayDataInGrid(cmd, usersBookings);
        }
    }
}
