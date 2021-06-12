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
using Microsoft.Office.Interop.Excel;

namespace BookingSystemGUI.User_Control_Backend
{
   
    public partial class Uc_manageSchedules : UserControl
    {
        int scheduleId;
        SqlCommand cmd;
        
        private static IsqlDataFunctions _isqlDataFunctions;
        public Uc_manageSchedules(IsqlDataFunctions dataFunctions)
        {
            _isqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new User_Control_Backend.Uc_manageSchedules(sqlDataFunctions);
        }
        public Uc_manageSchedules()
        {           
            InitializeComponent();
            creationOfSqlDataFunctions();
            DisplayAllSchedules();          
            button1.Enabled = false;
                   
        }       
        private void button5_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(manageSchedulePanel, new Uc_manageCoaches());                    
        }

        public void clearFields() 
        {
            txtStationDeparture.Text = "";
            txtStationArrival.Text = "";
            txtTimeOfDeparture.Text = "";
            txtTimeOfArrival.Text = "";
            dateOfDeparture.Text = "";
            txtPrice.Text = "";
            txtCoachId.Text = "";
            comboBoxStatus.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
            scheduleId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); 
            txtStationDeparture.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            txtStationArrival.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtTimeOfDeparture.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            txtTimeOfArrival.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            dateOfDeparture.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            txtPrice.Text = (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            txtCoachId.Text = (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            comboBoxStatus.Text = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            button1.Enabled = true;
          
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtStationDeparture.Text) || string.IsNullOrEmpty(txtStationArrival.Text) || string.IsNullOrEmpty(txtTimeOfDeparture.Text) || string.IsNullOrEmpty(txtTimeOfArrival.Text) || string.IsNullOrEmpty(dateOfDeparture.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtCoachId.Text) || string.IsNullOrEmpty(comboBoxStatus.Text)) 
            {
                MessageBox.Show("Please ensure that all fields have been filled before attempting to add a schedule.");
            }
            else 
            {
                string query = "Insert into coachSchedule (stationDeparture, stationArrival, timeOfDeparture, timeOfArrival, dateOfDeparture, Price, coachId, status) values (@stationDeparture, @stationArrival, @timeOfDeparture, @timeOfArrival, @dateOfDeparture, @price, @coachId, @status)";

                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@stationDeparture", txtStationDeparture.Text.Trim());
                cmd.Parameters.AddWithValue("@stationArrival", txtStationArrival.Text.Trim());
                cmd.Parameters.AddWithValue("@timeOfDeparture", txtTimeOfDeparture.Text);
                cmd.Parameters.AddWithValue("@timeOfArrival", txtTimeOfArrival.Text);
                cmd.Parameters.AddWithValue("@dateOfDeparture", dateOfDeparture.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@coachId", txtCoachId.Text.Trim());
                cmd.Parameters.AddWithValue("@status", comboBoxStatus.Text.Trim());

                _isqlDataFunctions.checkingCoachAvailability(cmd, int.Parse(txtCoachId.Text), "Coach schedule has been added succesfully!");
             
                DisplayAllSchedules();
                clearFields();
            }                
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtStationDeparture.Text) || string.IsNullOrEmpty(txtStationArrival.Text) || string.IsNullOrEmpty(txtTimeOfDeparture.Text) || string.IsNullOrEmpty(txtTimeOfArrival.Text) || string.IsNullOrEmpty(dateOfDeparture.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtCoachId.Text) || string.IsNullOrEmpty(comboBoxStatus.Text))
            {
                MessageBox.Show("Please ensure that all fields have been filled before attempting to update a schedule.");
            }
            else 
            {
                string query = ("update coachSchedule set stationDeparture= @stationDeparture, stationArrival = @stationArrival, timeOfDeparture= @timeOfDeparture, timeOfArrival= @timeOfArrival, dateOfDeparture= @dateOfDeparture, Price= @price, coachId= @coachId, status = @status WHERE coachScheduleId = @coachScheduleId ");

                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@stationDeparture", txtStationDeparture.Text.Trim());
                cmd.Parameters.AddWithValue("@stationArrival", txtStationArrival.Text.Trim());
                cmd.Parameters.AddWithValue("@timeOfDeparture", txtTimeOfDeparture.Text);
                cmd.Parameters.AddWithValue("@timeOfArrival", txtTimeOfArrival.Text);
                cmd.Parameters.AddWithValue("@dateOfDeparture", dateOfDeparture.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@coachId", txtCoachId.Text.Trim());
                cmd.Parameters.AddWithValue("@status", comboBoxStatus.Text.Trim());
                cmd.Parameters.AddWithValue("@coachScheduleId", scheduleId);
                

                _isqlDataFunctions.ManagingData(cmd, "Coach Schedule has been updated succesfully!");
                DisplayAllSchedules();
                clearFields();
                button1.Enabled = false;
                
            }        
        }

        private void DisplayAllSchedules() 
        {
            string query = "SELECT * FROM coachSchedule; SELECT cs.coachScheduleId, cs.stationDeparture, cs.stationArrival, cs.timeOfDeparture, cs.timeOfArrival, cs.dateOfDeparture, cs.Price, cs.coachId, cs.status, c.coachName, c.coachType, c.numberOfSeats from coachSchedule cs JOIN Coach c ON cs.coachId = c.CoachId";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);               
        }

        private void searchScheduleBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtScheduleId.Text)) 
            {
                MessageBox.Show("Error : please enter a schedule Id within the field provided!");
            }
            else 
            {
                string query = "SELECT cs.coachScheduleId, cs.stationDeparture, cs.stationArrival, cs.timeOfDeparture, cs.timeOfArrival, cs.dateOfDeparture, cs.Price, cs.coachId, cs.status, c.coachName, c.coachType, c.numberOfSeats from coachSchedule cs JOIN Coach c ON cs.coachId = c.CoachId WHERE coachScheduleId= @coachSchedule";

                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@coachSchedule", txtScheduleId.Text);

                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if(dataGridView1.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately the schedule Id you have entered does not exist!");
                }
            }   
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtJourneyFrom.Text) || string.IsNullOrEmpty(txtJourneyToo.Text)) 
            {
                MessageBox.Show("Error: please ensure that you have entered a location in both fields provided!");
            }
            else 
            {
                string query = "SELECT cs.coachScheduleId, cs.stationDeparture, cs.stationArrival, cs.timeOfDeparture, cs.timeOfArrival, cs.dateOfDeparture, cs.Price, cs.coachId, cs.status, c.coachName, c.coachType, c.numberOfSeats from coachSchedule cs JOIN Coach c ON cs.coachId = c.CoachId WHERE cs.stationDeparture = @stationDeparture AND cs.stationArrival = @stationArrival";
                
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@stationDeparture", txtJourneyFrom.Text);
                cmd.Parameters.AddWithValue("@stationArrival", txtJourneyToo.Text);

                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if(dataGridView1.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately there are no schedules that exist with the locations you have entered!");
                }
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayAllSchedules();
        }
       
        private void button9_Click(object sender, EventArgs e)
        {
            UserControlFeatures.ExportDataToExcel(dataGridView1);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            clearFields();
            button1.Enabled = false;
            
        }
    }
}
