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
    public partial class Uc_manageCoaches : UserControl
    {
        int coachId;
        SqlCommand cmd;
        private static IsqlDataFunctions _isqlDataFunctions;
        public Uc_manageCoaches(IsqlDataFunctions dataFunctions)
        {
            _isqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new User_Control_Backend.Uc_manageCoaches(sqlDataFunctions);
        }
        public Uc_manageCoaches()
        {
            InitializeComponent();            
            creationOfSqlDataFunctions();
            ViewAllCoachs();
            button1.Enabled = false;
            button2.Enabled = false;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            coachId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCoachName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxCoachType.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBoxNoOfSeats.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            button1.Enabled = true;
            button2.Enabled = true;
        }
        private void clearFields()
        {
            txtCoachName.Text = "";
            comboBoxCoachType.Text = "";
            comboBoxNoOfSeats.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtCoachName.Text) || string.IsNullOrEmpty(comboBoxCoachType.Text) || string.IsNullOrEmpty(comboBoxNoOfSeats.Text)) 
            {
                MessageBox.Show("Error: please ensure that all fields have been filled!");
            }
            else if(int.Parse(comboBoxNoOfSeats.Text) != 28) 
            {
                MessageBox.Show("Please ensure that the number of seats entered is from one of the options provided!");
            }
            else 
            {
                string query = "Insert into Coach (coachName, coachType, numberOfSeats) values (@coachName, @coachType, @NoOfSeats)";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@coachName", txtCoachName.Text);
                cmd.Parameters.AddWithValue("@coachType", comboBoxCoachType.Text);
                cmd.Parameters.AddWithValue("@NoOfSeats", comboBoxNoOfSeats.Text);
                _isqlDataFunctions.ManagingData(cmd, "Coach has been added succesfully!");
                clearFields();
                ViewAllCoachs();
            }          
        }
       
        private void ViewAllCoachs() 
        {           
            _isqlDataFunctions.displayDataInGrid("Select * from Coach", dataGridView1);
        }
             
        private void button2_Click(object sender, EventArgs e)
        {           
            cmd = new SqlCommand("DELETE Coach WHERE CoachId = @coachId", _isqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@coachId", coachId);

            _isqlDataFunctions.ManagingData(cmd, "Coach has been deleted succesfully!");
            _isqlDataFunctions.OrganisingSchedules();

            clearFields();
            button1.Enabled = false;
            button2.Enabled = false;
            ViewAllCoachs();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCoachName.Text) || string.IsNullOrEmpty(comboBoxCoachType.Text) || string.IsNullOrEmpty(comboBoxNoOfSeats.Text)) 
            {
                MessageBox.Show("Error: please ensure that all fields have been filled when attempting to update the coaches details.");
            }
            else
            {
                string query = "UPDATE Coach set coachName= @coachName, coachType= @coachType, numberOfSeats= @NoOfSeats WHERE CoachId= @coachId";

                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@coachName", txtCoachName.Text);
                cmd.Parameters.AddWithValue("@coachType", comboBoxCoachType.Text);
                cmd.Parameters.AddWithValue("@NoOfSeats", comboBoxNoOfSeats.Text);
                cmd.Parameters.AddWithValue("@coachId", coachId);
                _isqlDataFunctions.ManagingData(cmd, "Coach details have been updated succesfully!");

                clearFields();
                button1.Enabled = false;
                button2.Enabled = false;
                ViewAllCoachs();
            }         
        }
        private void button9_Click(object sender, EventArgs e)
        {
            UserControlFeatures.ExportDataToExcel(dataGridView1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(manageCoachesPanel, new Uc_manageSchedules());
        }
        private void button7_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ViewAllCoachs();
        }

        private void searchCoachBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCoachId.Text)) 
            {
                MessageBox.Show("Please ensure that you have entered an Id within the field provided!");
            }
            else 
            {
                cmd = new SqlCommand("SELECT * FROM Coach Where CoachId = @coachId", _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@coachId", txtCoachId.Text);
                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if(dataGridView1.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately the coach Id you have entered does not exist, please try again");
                }
            }           
        }
    }
}
