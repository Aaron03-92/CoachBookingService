using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingSystemGUI
{
    public partial class SignIn : Form
    {

        public static List<CustomerLogin> userDetails = new List<CustomerLogin>();
        SqlCommand cmd;
        
        private static IsqlDataFunctions _IsqlDataFunctions;
        public SignIn(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new SignIn(sqlDataFunctions);
        }
        public SignIn()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
            
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT c.customerId, c.firstname, c.lastname, c.address, c.contactNumber, cl.customerLoginId, cl.email, cl.password FROM customer c Join customerLogin cl ON cl.customerId = c.customerId where cl.email =@email AND cl.password=@password";

            cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@email", signInEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@password", Security.hashPassword(signInPassword.Text.Trim()));

            _IsqlDataFunctions.GetCustomerLoginDetails(cmd, userDetails);
            _IsqlDataFunctions.Login(cmd, new SignIn(), new Dashboard());
                        
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            var customerEmails = _IsqlDataFunctions.CheckingIfEmailExists("SELECT email FROM customerLogin");

        
             if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text)  || string.IsNullOrEmpty(txtboxAddress.Text) || string.IsNullOrEmpty(txtboxContact.Text)  || string.IsNullOrEmpty(txtEmailAddress.Text) || string.IsNullOrEmpty( txtPassword.Text))
            {
                MessageBox.Show("Please ensure all fields have been entered!");
            }
            else if(customerEmails.Count >= 1 && customerEmails.Contains(txtEmailAddress.Text)) 
            {
                MessageBox.Show("Unfortunately that email already exists!");
            }
            else
            {
                string query_1 = "Insert into customer (firstName, lastName, address, contactNumber) values (@firstName, @lastname, @address, @contact)";
                string query_2 = "SELECT MAX(customerId) from customer";
                string query_3 = "Insert into customerLogin (email, password, customerId) Values (@email, @password, @customerId)";

                _IsqlDataFunctions.GetConnection().Open();
                cmd = new SqlCommand(query_1, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@address", txtboxAddress.Text);
                cmd.Parameters.AddWithValue("@contact", txtboxContact.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
                var customerId = cmd.ExecuteScalar();

                cmd = new SqlCommand(query_3, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Security.hashPassword(txtPassword.Text.Trim()));
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.ExecuteNonQuery();
                _IsqlDataFunctions.GetConnection().Close();
                MessageBox.Show("Your account has been registered succesfully!");
                clearFields();
            }
        }

        private void adminLoginBtn_Click(object sender, EventArgs e)
        {
            GUIFunctionality.RevealForm(new SignIn(), new GUI_Designs.Admin_Login.adminLogin());

        }
        public static int GetCustomerId()
        {
            int id = 0;
            foreach (var i in SignIn.userDetails)
            {
                id = i.CustomerId;
            }
            return id;
        }
        public static int GetCustomerLoginId()
        {
            int id = 0;
            foreach (var i in SignIn.userDetails)
            {
                id = i.CustomerLoginId;
            }
            return id;
        }
        public void clearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmailAddress.Text = "";
            txtboxAddress.Text = "";
            txtPassword.Text = "";
            txtboxContact.Text = "";
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
       
    }
}
