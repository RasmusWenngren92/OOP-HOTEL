
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HOTEL
{
    public class HotelBooking
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public HotelBooking(DateTime aStartDate, int alengthOfStayInDays)
        {
            startDate = aStartDate;
            endDate = aStartDate.AddDays(alengthOfStayInDays);
        }
        
        public void DisplayBookingInfo()
        {
            Console.WriteLine($"Startdatum: {startDate:d}");
            Console.WriteLine($"Slutdatum: {endDate:d}");
        }
    }
}
