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
    public partial class Uc_manageCustomers : UserControl
    {
        int customerId;
        SqlCommand cmd;
        private static IsqlDataFunctions _isqlDataFunctions;
        public Uc_manageCustomers(IsqlDataFunctions dataFunctions)
        {
            _isqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new User_Control_Backend.Uc_manageCustomers(sqlDataFunctions);
        }
        public Uc_manageCustomers()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
            ViewAllCustomers();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            customerId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtUserFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUserLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtUserAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUserContactNo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtUserEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtUserPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            button1.Enabled = true;
            button2.Enabled = true;
        }
        private void clearFields()
        {
            txtUserFirstName.Text = "";
            txtUserLastName.Text = "";
            txtUserAddress.Text = "";
            txtUserContactNo.Text = "";
            txtUserEmail.Text = "";
            txtUserPassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete cl FROM customerLogin cl WHERE cl.customerId = @customerId; DELETE b FROM Bookings b WHERE b.customerId = @customerId; DELETE c FROM customer c WHERE c.customerId = @customerId";                   
            cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@customerId", customerId);            

            DialogResult dialogResult = MessageBox.Show("Are you should you would like to delete this customer? Please note that all related bookings will also be removed from the database", "Warning",  MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes) 
            {
                _isqlDataFunctions.ManagingData(cmd, "Customer has been deleted succesfully!");
            }

            clearFields();           
            ViewAllCustomers();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserFirstName.Text) || string.IsNullOrEmpty(txtUserLastName.Text) ||string.IsNullOrEmpty(txtUserAddress.Text) || string.IsNullOrEmpty(txtUserContactNo.Text) || string.IsNullOrEmpty(txtUserEmail.Text) || string.IsNullOrEmpty(txtUserPassword.Text)) 
            {
                MessageBox.Show("Please ensure that all fields have been filled when attempting to update a customers details.");
            }
            else 
            {
                string query = "Update customerLogin SET email = @email, password = @password WHERE customerId = @customerId; Update customer SET firstName= @firstName, lastName= @lastName, address= @address, contactNumber= @contact WHERE customerId = @customerId";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@email", txtUserEmail.Text);
                cmd.Parameters.AddWithValue("@password", Security.hashPassword(txtUserPassword.Text.Trim()));
                cmd.Parameters.AddWithValue("@firstName", txtUserFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", txtUserLastName.Text);
                cmd.Parameters.AddWithValue("@address", txtUserAddress.Text);
                cmd.Parameters.AddWithValue("@contact", txtUserContactNo.Text);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                _isqlDataFunctions.ManagingData(cmd, "Customer details have been updated");

                clearFields();
                ViewAllCustomers();
                button1.Enabled = false;
                button2.Enabled = false;
            }   
        }
      
        private void searchUserBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserId.Text)) 
            {
                MessageBox.Show("Error: please ensure that an Id has been entered within the field provided");
            }
            else 
            {
                string query = "SELECT c.customerId, c.firstName, c.lastName, c.address, c.contactNumber, cl.email, cl.password FROM customer c JOIN customerLogin cl ON c.customerId = cl.customerId WHERE c.customerId = @customerId";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@customerId", txtUserId.Text);
                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Unfortunately no customers exist under the Id you have entered!");
                }
            }           
        }

        private void searchUserNameBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) 
            {
                MessageBox.Show("Please ensure that you have entered a name within the field provided!");
            }
            else 
            {
                string query = "SELECT c.customerId, c.firstName, c.lastName, c.address, c.contactNumber, cl.email, cl.password FROM customer c JOIN customerLogin cl ON c.customerId = cl.customerId WHERE c.lastName LIKE @name + '%' ";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@name", txtUserName.Text);
                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);

                if(dataGridView1.Rows.Count == 0) 
                {
                    MessageBox.Show("Unfortunately the customer name you have entered does not exist!");
                }
            }         
        }
        private void ViewAllCustomers() 
        {
            string query = "SELECT c.customerId, c.firstName, c.lastName, c.address, c.contactNumber, cl.email, cl.password FROM customer c JOIN customerLogin cl ON c.customerId = cl.customerId";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT c.customerId, c.firstName, c.lastName, c.address, c.contactNumber, cl.email, cl.password FROM customer c JOIN customerLogin cl ON c.customerId = cl.customerId ORDER BY firstName";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT c.customerId, c.firstName, c.lastName, c.address, c.contactNumber, cl.email, cl.password FROM customer c JOIN customerLogin cl ON c.customerId = cl.customerId ORDER BY firstName DESC";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "SELECT c.customerId, c.firstName, c.lastName, c.address, c.contactNumber, cl.email, cl.password FROM customer c JOIN customerLogin cl ON c.customerId = cl.customerId ORDER BY customerId";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT c.customerId, c.firstName, c.lastName, c.address, c.contactNumber, cl.email, cl.password FROM customer c JOIN customerLogin cl ON c.customerId = cl.customerId ORDER BY customerId DESC";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewAllCustomers();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserControlFeatures.ExportDataToExcel(dataGridView1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(userManagementPanel, new Uc_customerPayments());
        }
    }
}
