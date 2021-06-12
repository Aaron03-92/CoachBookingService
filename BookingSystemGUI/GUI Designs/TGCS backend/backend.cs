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


namespace BookingSystemGUI.GUI_Designs.TGCS_backend
{
    public partial class backend : Form
    {
        public backend()
        {
            InitializeComponent();         
        }
      
        private void manageBookingBtn_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(backendPanel, new User_Control_Backend.Uc_manageBooking());            
        }

        private void manageAdminBtn_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(backendPanel, new User_Control_Backend.Uc_manageAdmin());           
        }

        private void manageCustomerBtn_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(backendPanel, new User_Control_Backend.Uc_manageCustomers());          
        }

        private void manageCoachbtn_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(backendPanel, new User_Control_Backend.Uc_manageSchedules());           
        }
        private void adminLogoutBtn_Click(object sender, EventArgs e)
        {
            GUIFunctionality.RevealForm(new backend(), new GUI_Designs.Admin_Login.adminLogin());         
        }
    }
}
