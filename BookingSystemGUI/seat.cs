using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingSystemGUI
{
    public class seat : PictureBox
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public int Number { get; set; }
        public string Seat => $"{Row}{Number}";
        public bool Available { get; set; }
    }
}
