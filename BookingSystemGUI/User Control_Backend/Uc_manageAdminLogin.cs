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
    public partial class Uc_manageAdminLogin : UserControl
    {
        SqlCommand cmd;
        int employeeId, employeeLoginId;
        private static IsqlDataFunctions _isqlDataFunctions;
        public Uc_manageAdminLogin(IsqlDataFunctions dataFunctions)
        {
            _isqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new User_Control_Backend.Uc_manageAdminLogin(sqlDataFunctions);
        }
        public Uc_manageAdminLogin()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
            
        }
      
        private void button6_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(manageAdminLoginPanel, new User_Control_Backend.Uc_manageAdmin());            
        }
 
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Error: Please ensure that both fields has been filled.");
            } else if(txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("your new password and confirmation password do not match! ");
            }
            else 
            {
                string query = "UPDATE employeeLogin SET password= @password WHERE employeeLoginId = @employeeLoginId";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());               
                cmd.Parameters.AddWithValue("@password", Security.hashPassword(txtConfirmPassword.Text.Trim()));
                cmd.Parameters.AddWithValue("@employeeLoginId", employeeLoginId);

                _isqlDataFunctions.ManagingData(cmd, "Login details have been updated succesfully!");           
                
                clearFields();
            }       
        }
        public void clearFields()
        {
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";       
        } 
        private void LoadEmployeeDetails() 
        {
            foreach (var i in GUI_Designs.Admin_Login.adminLogin.employeeDetails)
            {
                AdminFirstName.Text = i.FirstName;
                AdminLastName.Text = i.LastName;
                comboBoxAdminPosition.Text = i.Position;
                AdminContact.Text = i.ContactNumber;
                AdminEmail.Text = i.Email;
                employeeId = i.EmployeeId;
                employeeLoginId = i.EmployeeLoginId;
            }
        }

        private void Uc_manageAdminLogin_Load(object sender, EventArgs e)
        {
            LoadEmployeeDetails();
        }

        private void UpdateEmployeeLoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AdminFirstName.Text) || string.IsNullOrEmpty(AdminLastName.Text) || string.IsNullOrEmpty(comboBoxAdminPosition.Text) || string.IsNullOrEmpty(AdminContact.Text) || string.IsNullOrEmpty(AdminEmail.Text))
            {
                MessageBox.Show("Error: please ensure that all fields have been filled!");
            }
            else
            {
                string query_1 = "UPDATE employee SET firstName = @firstName, lastName = @lastName, position = @position, contactNumber = @contactNumber WHERE employeeId = @employeeId";
                string query_2 = "UPDATE employeeLogin SET email = @email WHERE employeeLoginId = @employeeLoginId";
                cmd = new SqlCommand(query_1, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@firstName", AdminFirstName.Text);
                cmd.Parameters.AddWithValue("@lastName", AdminLastName.Text);
                cmd.Parameters.AddWithValue("@position", comboBoxAdminPosition.Text);
                cmd.Parameters.AddWithValue("@contactNumber", AdminContact.Text);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                _isqlDataFunctions.ManagingData(cmd);

                cmd = new SqlCommand(query_2, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@email", AdminEmail.Text);
                cmd.Parameters.AddWithValue("@employeeLoginId", employeeLoginId);
                _isqlDataFunctions.ManagingData(cmd, "Your details have been updated succesfully!");
            
            }
        }
    }
}
