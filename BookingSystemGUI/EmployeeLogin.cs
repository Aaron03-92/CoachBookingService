using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGUI
{
    public class EmployeeLogin
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string ContactNumber { get; set; }
        public int EmployeeLoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString() => $"{EmployeeId}, {FirstName}, {LastName}, {Position}, {ContactNumber}, {EmployeeLoginId}, {Email}, {Password}";
    }
}
