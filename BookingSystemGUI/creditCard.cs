using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGUI
{
    class creditCard
    {
        public int Id { get; set; }
        public string CardType {get; set;}
        public Int64 CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpiryDate { get; set; }
        public int CustomerID { get; set; }

        public override string ToString() => $"{Id}{CardType}{CardNumber}{NameOnCard}{ExpiryDate}{CustomerID}";
 
    }
}
