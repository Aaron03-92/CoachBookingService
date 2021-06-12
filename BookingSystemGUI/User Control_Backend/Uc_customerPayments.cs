using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookingSystemGUI.User_Control_Backend
{
    public partial class Uc_customerPayments : UserControl
    {

        SqlCommand cmd;
        private static IsqlDataFunctions _isqlDataFunctions;
        public Uc_customerPayments(IsqlDataFunctions dataFunctions)
        {
            _isqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_customerPayments(sqlDataFunctions);
        }
        public Uc_customerPayments()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
            LoadPayments();
        }
        private void LoadPayments() 
        {
                       
            string query = "SELECT p.paymentId, c.firstName, c.lastName, bc.cardType, bc.cardNumber, p.amount, p.dateOfPurchase,  p.bookingId FROM customer c JOIN bankCard bc ON c.customerId = bc.customerId JOIN payment p ON p.bankCardId = bc.cardId";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(userPaymentPanel, new Uc_manageCustomers());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserControlFeatures.ExportDataToExcel(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "SELECT p.paymentId, c.firstName, c.lastName, bc.cardType, bc.cardNumber, p.amount, p.dateOfPurchase, p.bookingId FROM customer c JOIN bankCard bc ON c.customerId = bc.customerId JOIN payment p ON p.bankCardId = bc.cardId ORDER BY bc.cardId";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT p.paymentId, c.firstName, c.lastName, bc.cardType, bc.cardNumber, p.amount, p.dateOfPurchase, p.bookingId FROM customer c JOIN bankCard bc ON c.customerId = bc.customerId JOIN payment p ON p.bankCardId = bc.cardId ORDER BY bc.cardId DESC";
            _isqlDataFunctions.displayDataInGrid(query, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields() 
        {
            txtUserFirstName.Text = "";
            txtUserLastName.Text = "";
            txtPaymentId.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadPayments();
        }
        private void searchFirstNameBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserFirstName.Text))
            {
                MessageBox.Show("Error: please ensure a first name has been entered before clicking search");
            }
            else
            {
                string query = "SELECT p.paymentId, c.firstName, c.lastName, bc.cardType, bc.cardNumber, p.amount, p.dateOfPurchase,  p.bookingId FROM customer c JOIN bankCard bc ON c.customerId = bc.customerId JOIN payment p ON p.bankCardId = bc.cardId WHERE c.firstName = @firstName";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@firstName", txtUserFirstName.Text);
                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);
            }
        }
        private void searchLastNameBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserLastName.Text))
            {
                MessageBox.Show("Error: please ensure a lastname has been entered before clicking search");
            }
            else
            {
                string query = "SELECT p.paymentId, c.firstName, c.lastName, bc.cardType, bc.cardNumber, p.amount, p.dateOfPurchase, p.bookingId FROM customer c JOIN bankCard bc ON c.customerId = bc.customerId JOIN payment p ON p.bankCardId = bc.cardId WHERE c.lastName = @lastName";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@lastName", txtUserLastName.Text);
                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);
            }
        }
        private void searchpaymentId_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaymentId.Text)) 
            {
                MessageBox.Show("Error: please ensure that an Id has been entered within the field provided");
            }
            else
            {
                string query = "SELECT p.paymentId, c.firstName, c.lastName, bc.cardType, bc.cardNumber, p.amount, p.dateOfPurchase, p.bookingId FROM customer c JOIN bankCard bc ON c.customerId = bc.customerId JOIN payment p ON p.bankCardId = bc.cardId WHERE p.paymentId = @paymentId";
                cmd = new SqlCommand(query, _isqlDataFunctions.GetConnection());
                cmd.Parameters.AddWithValue("@paymentId", txtPaymentId.Text);
                _isqlDataFunctions.displayDataInGrid(cmd, dataGridView1);
            }         
        }    
    }
}
