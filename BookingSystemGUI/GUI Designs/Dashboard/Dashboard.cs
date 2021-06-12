using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingSystemGUI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            hideMenuPanel();
            hideOptionsMenu();
            
        }
        private void hideMenuPanel() 
        {
            bookingsMenuPanel.Visible = false;
        }
        private void hideOptionsMenu() 
        {
            if (bookingsMenuPanel.Visible == true) 
            {
                bookingsMenuPanel.Visible = false;
            }
        }
        private void ShowMenu(Panel menu)
        {
            if (menu.Visible == false)
            {
                menu.Visible = true;
            }
            else
            {
                menu.Visible = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShowMenu(bookingsMenuPanel);
        }

        private void button4_Click(object sender, EventArgs e)
        {          
            hideMenuPanel();
            GUIFunctionality.ShowUserControl(bookingControlPanel, new User_Control.Uc_addBooking());        
        }
        private void button5_Click(object sender, EventArgs e)
        {
            hideMenuPanel();
            GUIFunctionality.ShowUserControl(bookingControlPanel, new User_Control.Uc_myBookings());          
        }
        private void button6_Click(object sender, EventArgs e)
        {
            GUIFunctionality.RevealForm(new Dashboard(), new SignIn());        
        }

        public void button3_Click(object sender, EventArgs e)
        {
            GUIFunctionality.ShowUserControl(bookingControlPanel, new User_Control.Uc_updateAccountDetails());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bookingControlPanel.Controls.Clear();            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideMenuPanel();
            GUIFunctionality.ShowUserControl(bookingControlPanel, new User_Control.Uc_payments());
        }
    }
}
