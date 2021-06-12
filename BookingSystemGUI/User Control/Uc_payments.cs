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
    public partial class Uc_payments : UserControl
    {
        SqlCommand cmd;
        private static IsqlDataFunctions _IsqlDataFunctions;
        public Uc_payments(IsqlDataFunctions dataFunctions)
        {
            _IsqlDataFunctions = dataFunctions;
        }
        public static void creationOfSqlDataFunctions()
        {
            SqlDataFunctions sqlDataFunctions = new SqlDataFunctions();
            new Uc_payments(sqlDataFunctions);
        }
        public Uc_payments()
        {
            InitializeComponent();
            creationOfSqlDataFunctions();
        }

        private void Uc_payments_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM bankCard WHERE customerId = @customerId";
            cmd = new SqlCommand(query, _IsqlDataFunctions.GetConnection());
            cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());
            _IsqlDataFunctions.displayDataInGrid(cmd, dataGridView1);
            
        }
    }
}
