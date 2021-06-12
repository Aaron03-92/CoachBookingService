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
    public partial class Uc_manageAdmin : UserControl
    {
        SqlCommand cmd;
        int employeeId;

        private static IsqlDataFunctions _IsqlDataFunctions;
        public Uc_manageAdmin(IsqlDataFunctions dataFunctions) 
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new User_Control_Backend.Uc_manageAdmin(sqlDataFunctions);
        }
        public Uc_manageAdmin()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
            ViewAllAdminData();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            employeeId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtAdminFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAdminLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBoxAdminPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAdminContact.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAdminEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtAdminPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtAdminPassword.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
        }
        public void clearFields()
        {
            txtAdminFirstName.Text = "";
            txtAdminLastName.Text = "";
            comboBoxAdminPosition.Text = "";
            txtAdminContact.Text = "";
            txtAdminEmail.Text = "";
            txtAdminPassword.Text = "";
        }
  
        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            var adminEmails = _IsqlDataFunctions.CheckingIfEmailExists("SELECT email FROM employeeLogin");

            if (string.IsNullOrEmpty(txtAdminFirstName.Text) || string.IsNullOrEmpty(txtAdminLastName.Text) || string.IsNullOrEmpty(comboBoxAdminPosition.Text) || string.IsNullOrEmpty(txtAdminContact.Text) || string.IsNullOrEmpty(txtAdminEmail.Text) || string.IsNullOrEmpty(txtAdminPassword.Text))
            {
                MessageBox.Show("Error : please ensure that all fields have been filled out!");
            }
            else if(adminEmails.Count >= 1 && adminEmails.Contains(txtAdminEmail.Text)) 
            {
                MessageBox.Show("Unfortunately that email already exists!");
            }
            else 
            {
                string query_1 = "Insert into employee (firstName, lastName, position, contactNumber) values ( @firstName, @lastName, @position, @contact)";
                string query_2 = "SELECT MAX(employeeId) FROM employee";
                string query_3 = "Insert into employeeLogin (email, password, employeeId) values (@email, @password, @employeeId)";

                _IsqlDataFunctions.GetConnection().Open();
                cmd = new SqlCommand(query_1, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@firstName", txtAdminFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", txtAdminLastName.Text);
                cmd.Parameters.AddWithValue("@position", comboBoxAdminPosition.Text);
                cmd.Parameters.AddWithValue("@contact", txtAdminContact.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
                var employeeId = cmd.ExecuteScalar();

                cmd = new SqlCommand(query_3, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@email", txtAdminEmail.Text);
                cmd.Parameters.AddWithValue("@password", Security.hashPassword(txtAdminPassword.Text.Trim()));
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.ExecuteNonQuery();
                _IsqlDataFunctions.GetConnection().Close();

                MessageBox.Show("Employee has been added succesfully!");
                clearFields();
                ViewAllAdminData();
            }                                                           
        }

        private void searchAdminIdBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdminID.Text))
            {
                MessageBox.Show("Error: please ensure that you have entered an Id within the field provided!");
            }
            else
            {
                string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.email, el.password FROM employee e JOIN employeeLogin el ON e.employeeId = el.employeeId WHERE e.employeeId= @employeeId";
                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@employeeId", txtAdminID.Text);
                _IsqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if(dataGridView1.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately the employee Id you have entered does not exist!");
                }
            }
        }
        private void searchAdminNameBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtAdminSearchName.Text)) 
            {
                MessageBox.Show("Error: please ensure you have entered a name within the field provided!");
            }
            else 
            {
                string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.email, el.password FROM employee e JOIN employeeLogin el ON e.employeeId = el.employeeId WHERE e.lastName LIKE @searchName + '%' ";
                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@searchName", txtAdminSearchName.Text);
                _IsqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Unfortunately the name you have entered does not exist!");
                }
            }      
        }

        private void ViewAllAdminData()
        {
            string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.email, el.password FROM employee e Join employeeLogin el ON e.employeeId = el.employeeId";
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }
               
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete el from employeeLogin el Where el.employeeId = @employeeID; Delete e from employee e Where e.employeeId = @employeeID";
            cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@employeeId", employeeId);
            _IsqlDataFunctions.ManagingData(cmd, "Employee has been deleted succesfully!");
           
            clearFields();
            ViewAllAdminData();
            txtAdminPassword.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdminFirstName.Text) || string.IsNullOrEmpty(txtAdminLastName.Text) || string.IsNullOrEmpty(comboBoxAdminPosition.Text) || string.IsNullOrEmpty(txtAdminContact.Text) || string.IsNullOrEmpty(txtAdminEmail.Text)) 
            {
                MessageBox.Show("Please ensure that all fields have been filled when attemping to update the employee details");
            }
            else 
            {
                string query = ("Update employeeLogin SET email = @email WHERE employeeId = @employeeId ; Update employee SET firstName= @firstName, lastName = @lastName, position= @position, contactNumber= @contactNumber WHERE employeeId = @employeeId ");

                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@email", txtAdminEmail.Text);
                cmd.Parameters.AddWithValue("@firstName", txtAdminFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", txtAdminLastName.Text);
                cmd.Parameters.AddWithValue("@position", comboBoxAdminPosition.Text);
                cmd.Parameters.AddWithValue("@contactNumber", txtAdminContact.Text);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);

                _IsqlDataFunctions.ManagingData(cmd, "Employee details have been updated");
                clearFields();
                ViewAllAdminData();
                txtAdminPassword.Enabled = true;
            }          
        }
      
        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.email, el.password FROM employee e JOIN employeeLogin el ON e.employeeId = el.employeeId ORDER BY e.firstName";
          
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.email, el.password FROM employee e JOIN employeeLogin el ON e.employeeId = el.employeeId ORDER BY e.firstName DESC";
       
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.email, el.password FROM employee e JOIN employeeLogin el ON e.employeeId = el.employeeId ORDER BY e.employeeId";
          ;
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.email, el.password FROM employee e JOIN employeeLogin el ON e.employeeId = el.employeeId ORDER BY e.employeeId DESC";
      
            _IsqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clearFields();
            txtAdminPassword.Enabled = true;           
            button1.Enabled = false;
            button2.Enabled = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(manageAdminPanel, new User_Control_Backend.Uc_manageAdminLogin());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewAllAdminData();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            UserControlFeatures.ExportDataToExcel(dataGridView1);
        }        
    }
}
