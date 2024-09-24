using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HOTEL
{
    public class Guest
    {
        public string guestName;

        public string email;
        public int phone;
        public static int guestCount;

        public Guest (string aGuestName, string aEmail, int aPhone)
        {
            guestName = aGuestName;
            email = aEmail;
            phone = aPhone;
            guestCount++;

        }
        public static int getGuestCount()
        {
            return guestCount;
        }
    }
}
