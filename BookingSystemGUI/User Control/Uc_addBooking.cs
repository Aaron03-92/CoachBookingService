using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookingSystemGUI.User_Control
{
    public partial class Uc_addBooking : UserControl
    {
        
        SqlCommand cmd;                 
        int totalSeatCount;
        string scheduleId, status;       

        private static IsqlDataFunctions _IsqlDataFunctions;
        public Uc_addBooking(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_addBooking(sqlDataFunctions);
        }
        public Uc_addBooking()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();      
        }

        private void Uc_addBooking_Load(object sender, EventArgs e)
        {          
            _IsqlDataFunctions.displayDataInComboBox("select (stationDeparture) from coachSchedule", "stationDeparture", comboBoxTravelFrom);
            _IsqlDataFunctions.displayDataInComboBox("select (stationArrival) from coachSchedule", "stationArrival", comboBoxTravelTo);

       

        }
        private void searchBookingBtn_Click(object sender, EventArgs e)
        {

            if (comboBoxTicketType.Text == "")
            {
                MessageBox.Show("Please select your ticket type!");
            }
            else 
            {
                string query = " SELECT cs.coachScheduleId, cs.stationDeparture, cs.stationArrival, cs.timeOfDeparture, cs.timeOfArrival, cs.dateOfDeparture, cs.status, c.numberOfSeats FROM coachSchedule cs JOIN Coach c ON cs.coachId = c.CoachId WHERE cs.dateOfDeparture BETWEEN @dateFrom AND @dateTo AND cs.stationDeparture= @travelFrom AND cs.stationArrival= @travelTo";
                                           
                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@dateFrom", dateFromPicker.Value);
                cmd.Parameters.AddWithValue("@dateTo", dateTooPicker.Value);
                cmd.Parameters.AddWithValue("@travelFrom", comboBoxTravelFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@travelTo", comboBoxTravelTo.SelectedValue);

                _IsqlDataFunctions.displayDataInGrid(cmd, availableBookings);

                if (availableBookings.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately no bookings can be found with the information you have entered. Please try again.");
                }
            }     
        }
    
        private void availableBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var bd = new User_Control.Uc_bookingDetails(); 
            scheduleId = (availableBookings.Rows[e.RowIndex].Cells[0].Value.ToString());
            totalSeatCount = int.Parse(availableBookings.Rows[e.RowIndex].Cells[7].Value.ToString());
            status = availableBookings.Rows[e.RowIndex].Cells[6].Value.ToString();
            bd.txtSchedule.Text = scheduleId;
            bd.txtTicketType.Text = comboBoxTicketType.Text;


            if (totalSeatCount == 0)
            {
                MessageBox.Show("Unfortunately there are no more spaces left. We apologise for any inconvenience caused!");             
            }
            else if(status == "Unavailable") 
            {
                MessageBox.Show("This journey is temporarily unavailable at the moment. We apologise for any inconvenience caused!");
            }
            else
            {
                if (comboBoxTicketType.Text == "Single")
                {
                    string query = "select cs.stationDeparture, cs.stationArrival , cs.timeOfDeparture, cs.timeOfArrival, cs.dateOfDeparture, cs.Price , c.coachId, c.coachName, c.coachType, c.numberOfSeats FROM coachSchedule cs  Inner Join Coach c ON cs.coachId = c.coachId WHERE coachScheduleId = @scheduleId";

                    cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                    cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                    _IsqlDataFunctions.displayDataInGrid(cmd, bd.confirmDetailsDataGrid);

                }
                else 
                {
                    string query = "select cs.stationDeparture, cs.stationArrival , cs.timeOfDeparture, cs.timeOfArrival, cs.dateOfDeparture, cs.Price*1.1 AS Price , c.coachId, c.coachName, c.coachType, c.numberOfSeats FROM coachSchedule cs  Inner Join Coach c ON cs.coachId = c.coachId WHERE coachScheduleId = @scheduleId";

                    cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                    cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                    _IsqlDataFunctions.displayDataInGrid(cmd, bd.confirmDetailsDataGrid);
                }
              
                GUIFunctionality.ShowUserControl(addBookingPanel, bd);              
            }         
        }       
    }
}
