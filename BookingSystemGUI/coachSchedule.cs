using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGUI
{
    public class coachSchedule
    {
        public int coachScheduleId { get; set; }
        public string StationDeparture { get; set; }
        public string StationArrival { get; set; }
        public string TimeOfDeparture { get; set; }
        public string TimeOfArrival { get; set; }     

        public override string ToString() => $"Coach schedule Id: {coachScheduleId} Station departure: {StationDeparture} Station Arrival: {StationArrival} Time of departure:{TimeOfDeparture} Time of arrival: {TimeOfArrival}\n";        
    }
}
