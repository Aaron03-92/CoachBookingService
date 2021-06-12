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



namespace BookingSystemGUI.GUI_Designs.Admin_Login
{
    public partial class adminLogin : Form
    {

        public static List<EmployeeLogin> employeeDetails = new List<EmployeeLogin>();
        SqlCommand cmd;
        private static IsqlDataFunctions _isqlDataFunctions;
        public adminLogin(IsqlDataFunctions dataFunctions)
        {
            _isqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new adminLogin(sqlDataFunctions);
        }

        public adminLogin()
        {
            creationOfSqlDataFunctions();
            InitializeComponent();
        }

        private void adminSignUpBtn_Click(object sender, EventArgs e)
        {
            var adminEmails = _isqlDataFunctions.CheckingIfEmailExists("SELECT email FROM employeeLogin");

            if (string.IsNullOrEmpty( txtAdminFirstName.Text) || string.IsNullOrEmpty( txtAdminLastName.Text) ||  string.IsNullOrEmpty(comboBoxAdminPosition.Text)  || string.IsNullOrEmpty( txtAdminPass.Text)  || string.IsNullOrEmpty(txtAdminContact.Text) || string.IsNullOrEmpty( txtAdminEmail.Text) )
            {
                MessageBox.Show("Error: please ensure all fields have been entered!");
            }
            else if(adminEmails.Count >=1 && adminEmails.Contains(txtAdminEmail.Text)) 
            {
                MessageBox.Show("Unfortunately that email already exists!");
            }
            else 
            {
                string query_1 = "Insert into employee  (firstName, lastName, position, contactNumber) VALUES (@firstName, @lastName, @position, @contact)";
                string query_2 = "SELECT MAX(employeeId) from employee";
                string query_3 = "Insert into employeeLogin (email, password, employeeId) VALUES (@email, @password, @employeeId)";

                _isqlDataFunctions.GetConnection().Open();
                cmd = new SqlCommand(query_1, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@firstName", txtAdminFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastname", txtAdminLastName.Text);
                cmd.Parameters.AddWithValue("@position", comboBoxAdminPosition.Text);
                cmd.Parameters.AddWithValue("@contact", txtAdminContact.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(query_2, _isqlDataFunctions.GetConnection());
                var employeeid = cmd.ExecuteScalar();

                cmd = new SqlCommand(query_3, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@email", txtAdminEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Security.hashPassword(txtAdminPass.Text.Trim()));
                cmd.Parameters.AddWithValue("@employeeId", employeeid);
                cmd.ExecuteNonQuery();
                _isqlDataFunctions.GetConnection().Close();
                MessageBox.Show("Your account has been registered succesfully!");
                clearFields();
                                
            }
        }
     
        private void adminSignInBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT e.employeeId, e.firstName, e.lastName, e.position, e.contactNumber, el.employeeLoginId, el.email, el.password FROM employee e JOIN employeeLogin el ON el.employeeId = e.employeeId WHERE email= @email AND password = @password ";

            cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@email", adminSignInEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@password", Security.hashPassword(adminSignInPass.Text.Trim()));

            _isqlDataFunctions.GetEmployeeDetails(cmd, employeeDetails);
            _isqlDataFunctions.Login(cmd, new adminLogin(), new TGCS_backend.backend());
                         
        }
        private void customerLoginbtn_Click(object sender, EventArgs e)
        {
            GUIFunctionality.RevealForm(new adminLogin(), new SignIn());            
        }
        private void clearFields()
        {
            txtAdminFirstName.Text = "";
            txtAdminLastName.Text = "";
            comboBoxAdminPosition.Text = "";
            txtAdminPass.Text = "";
            txtAdminContact.Text = "";
            txtAdminEmail.Text = "";
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
