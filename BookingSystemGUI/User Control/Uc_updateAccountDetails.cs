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
    public partial class Uc_updateAccountDetails : UserControl
    {
        SqlCommand cmd;
        private static IsqlDataFunctions _IsqlDataFunctions;
        public Uc_updateAccountDetails(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_updateAccountDetails(sqlDataFunctions);
        }
        public Uc_updateAccountDetails()
        {            
            InitializeComponent();
            creationOfSqlDataFunctions();
        }
       
        private void Uc_updateAccountDetails_Load(object sender, EventArgs e)
        {
            LoadCustomerDetails();
        }
        private void LoadCustomerDetails()
        {
                 
            foreach (var i in SignIn.userDetails)
            {
                accountFirstName.Text = i.FirstName;
                accountLastName.Text = i.LastName;
                accountAddress.Text = i.Address;
                accountContactNumber.Text = i.ContactNumber;
                accountEmail.Text = i.Email;
            }
        }
        private void updateDetailsBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(accountFirstName.Text) || string.IsNullOrEmpty(accountLastName.Text) || string.IsNullOrEmpty(accountAddress.Text) || string.IsNullOrEmpty(accountContactNumber.Text) || string.IsNullOrEmpty(accountEmail.Text)) 
            {
                MessageBox.Show("Please ensure that all fields have been filled!");
            }
            else 
            {
                string query_1 = ("Update customer set firstName= @firstName, lastName = @lastName, address= @address, contactNumber= @contact WHERE customerId= @customerId");
                string query_2 = "Update customerLogin set email = @email WHERE customerId = @customerId";

                cmd = new SqlCommand(query_1, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@firstName", accountFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", accountLastName.Text);
                cmd.Parameters.AddWithValue("@address", accountAddress.Text);
                cmd.Parameters.AddWithValue("@contact", accountContactNumber.Text);
                cmd.Parameters.AddWithValue("customerId", SignIn.GetCustomerId());
                _IsqlDataFunctions.ManagingData(cmd);

                cmd = new SqlCommand(query_2, _IsqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@email", accountEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());

                _IsqlDataFunctions.ManagingData(cmd, "Your details have been updated succesfully!");
                LoadCustomerDetails();
            }              
               
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassChange.Text) || string.IsNullOrEmpty(txtPassConfirm.Text))
            {
                MessageBox.Show("Please ensure that both fields have been filled!");
            }
            else if(txtPassChange.Text != txtPassConfirm.Text) 
            {
                MessageBox.Show("Your new password and confirmation password do not match!");
            }
            else
            {
                string query = "Update customerLogin set password= @password WHERE customerLoginId = @customerLoginId";
                cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());                
                cmd.Parameters.AddWithValue("@password", Security.hashPassword(txtPassChange.Text.Trim()));
                cmd.Parameters.AddWithValue("@customerLoginId", SignIn.GetCustomerLoginId());
                _IsqlDataFunctions.ManagingData(cmd, "Login credentals have been updated succesfully!");
                ClearPasswordAndEmail();
            }
         
        }     
        private void ClearPasswordAndEmail() 
        {            
            txtPassChange.Text = "";
            txtPassConfirm.Text = "";
        }   
    }
}
