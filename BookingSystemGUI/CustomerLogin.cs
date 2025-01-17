﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGUI
{
    public class CustomerLogin
    {
       
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int CustomerLoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString() => $"{CustomerId}, {FirstName}, {LastName}, {Address}, {ContactNumber}, {CustomerLoginId}, {Email}, {Password}";
       
    }   
}
