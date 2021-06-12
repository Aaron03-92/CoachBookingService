using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingSystemGUI
{
    class GUIFunctionality
    {
        public  static void  RevealForm(Control currentControl, Control GoToControl ) 
        {
            var form = GoToControl;
            currentControl.Hide();
            form.Show();
        }
        public static void ShowUserControl(Panel panel, Control control)
        {
            panel.Controls.Clear();

            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            panel.Controls.Add(control);
        }
    }
}
