using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BookingSystemGUI
{


    public interface IsqlDataFunctions
    {
        void Login(SqlCommand cmd, Control currentControl, Control gotoControl);       
        void ManagingData(string query);
        void ManagingData(SqlCommand cmd, string message);
        void ManagingData(SqlCommand cmd);
        void displayDataInGrid(SqlCommand cmd, DataGridView datagrid);
        void displayDataInGrid(string query, DataGridView datagrid);
        void displayDataInComboBox(string query, string columnName, ComboBox comboBox);    
        SqlConnection GetConnection();
        void GetEmployeeDetails(SqlCommand cmd, List<EmployeeLogin> userDetails);
        void GetCustomerLoginDetails(SqlCommand cmd, List<CustomerLogin> userDetails);
        void checkingCoachAvailability(SqlCommand cmd, int coachId, string message);
        List<string> CheckingIfEmailExists(string query);
        int GetBankCardId();
        void OrganisingSchedules();

    }
    class SqlDataFunctions : IsqlDataFunctions
    {

        public SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TGCSBookingSystem;Integrated Security=True");

        public static List<string> totalSeats = new List<string>();

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public void ManagingData(SqlCommand cmd, string message) 
        {
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                  
        }
        public void ManagingData(SqlCommand cmd) 
        {
            try 
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void ManagingData(string query) 
        {
            connection.Open();
            var cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Login(SqlCommand cmd, Control currentControl, Control gotoControl) 
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            if (dt.Rows.Count == 1)
            {
                var userControl = gotoControl;
                currentControl.Hide();
                userControl.Show();
            }
            else
            {
                MessageBox.Show("The login credentials you have entered are incorrect, please try again.");
            }
        }
        public void displayDataInGrid(SqlCommand cmd, DataGridView datagrid)
        {            
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                datagrid.DataSource = dt;

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Please ensure that you are entering a number within the field provided");
            }
            finally
            {
                connection.Close();
            }
        }
        public void displayDataInGrid(string query, DataGridView datagrid)
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                datagrid.DataSource = dt;
                connection.Close();
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
            }
            finally 
            {
                connection.Close();
            }
        }
        public void displayDataInComboBox(string query, string columnName, ComboBox comboBox)
        {
            try
            {
                connection.Open();
                SqlCommand sc = new SqlCommand(query, connection);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add(columnName, typeof(string));
                dt.Load(reader);
                comboBox.ValueMember = columnName;
                comboBox.DataSource = dt;
                connection.Close();
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
            }
        }
               
        public void GetCustomerLoginDetails(SqlCommand cmd, List<CustomerLogin> userDetails)
        {
            try
            {
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userDetails.Add(new CustomerLogin()
                    {
                        CustomerId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Address = reader.GetString(3),
                        ContactNumber = reader.GetString(4),
                        CustomerLoginId = reader.GetInt32(5),
                        Email = reader.GetString(6),
                        Password = reader.GetString(7),
                    });
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Your login credentials are incorrect");
            }
            connection.Close();

        }
        public void GetEmployeeDetails(SqlCommand cmd, List<EmployeeLogin> employeeDetails) 
        {
            try
            {
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeDetails.Add(new EmployeeLogin()
                    {
                        EmployeeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Position = reader.GetString(3),
                        ContactNumber = reader.GetString(4),
                        EmployeeLoginId = reader.GetInt32(5),
                        Email = reader.GetString(6),
                        Password = reader.GetString(7),
                    });
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Your login credentials are incorrect");
            }
            connection.Close();
        }
        public void checkingCoachAvailability(SqlCommand cmd, int coachId, string message)
        {
            int n = 1;
            var coachIdentification = new List<int>();

            var getData = "SELECT coachId FROM coachSchedule";
            SqlCommand sqlCommand = new SqlCommand(getData, connection);
            connection.Open();
            var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                coachIdentification.Add(reader.GetInt32(0));
            }

            foreach (var i in coachIdentification)
            {
                if (i == coachId)
                {
                    MessageBox.Show("Unfortunately the coach Id you have entered already belongs to another schedule within the database . Please select a Coach Id that is available or create another within the Manage Coach section of the backend");
                    connection.Close();
                    n = 0;
                    break;
                }
            }
            connection.Close();
            if (n == 1)
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(message);
            }

        }
        public List<string> CheckingIfEmailExists( string query)
        {
           
            var emails = new List<string>();
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                emails.Add(reader.GetString(0));
            }
            connection.Close();
            return emails;

        }          
        public void OrganisingSchedules() 
        {
            StringBuilder builder = new StringBuilder();
            var coachSchedules = new List<coachSchedule>();
            var query = "SELECT * FROM coachSchedule WHERE coachId IS NULL";
            
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                coachSchedules.Add(new coachSchedule()
                {
                    coachScheduleId = reader.GetInt32(0),
                    StationDeparture = reader.GetString(1),
                    StationArrival = reader.GetString(2),
                    TimeOfDeparture = reader.GetString(3),
                    TimeOfArrival = reader.GetString(4),
                   
                });                
            }
                          
            foreach(var schedule in coachSchedules) 
            {                
                builder.Append(schedule.ToString()).AppendLine();                
            }
           
            MessageBox.Show($"The following schedules do not have a designated coach Id, which will prevent customers from viewing them on the website.\nThis issue MUST be rectified immediately!\n\n{builder.ToString()}");
          
            
            connection.Close();
                          
        }      
        public int GetBankCardId() 
        {
            int bankCardId = 0;
             
            string query = "SELECT MAX(cardId) from bankCard WHERE customerId = @customerId";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@customerId", SignIn.GetCustomerId());

            var reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                bankCardId = reader.GetInt32(0);
            }
            connection.Close();
            return bankCardId;
        }
    }
}
