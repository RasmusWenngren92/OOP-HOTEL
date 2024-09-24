// Programmers:   Johannes, Onni, Rasmus
// Program:       Fullstack .NET 2024
// Course:        Programmering med C# och .NET
// Workshop:      OOP Hotel

namespace OOP_HOTEL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime bookingStart = DateTime.Now;
            int lengthOfStay = 0;
            HotelBooking newBooking = new HotelBooking(bookingStart, lengthOfStay);

            // Skapar en ny obj för varje gäst
            List<Guest> guestList = new List<Guest>(); // List to store guests

            bool programloop = true;
            while (programloop)
            {
                printMenu();
                string userInputs = Console.ReadLine().ToUpper();
                Console.Clear();

                switch (userInputs)
                {
                    case "A":
                        CreateGuest(guestList); // Function to add guests
                        Console.WriteLine("Hur många dagar vill du stanna?");
                        lengthOfStay = Convert.ToInt32(Console.ReadLine());

                        newBooking = new HotelBooking(bookingStart, lengthOfStay);

                        Console.WriteLine("Bokningen har skapats.\n");
                        break;

                    case "B":
                        printGuestList(guestList);
                        newBooking.DisplayBookingInfo();

                        Console.WriteLine("Antal gäster inbokade: " + Guest.getGuestCount());
                        break;

                    case "C":
                        searchForGuest(guestList);
                        break;

                    case "D":
                        Console.Clear();
                        Console.WriteLine("Programmet avslutas. Välkommen tillbaka!");
                        programloop = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        public static void printMenu()
        {
            Console.WriteLine("         Hej och välkommen till OOP Hotell         \n");
            Console.WriteLine("[A] Var god uppge bokningsinformation \n");
            Console.WriteLine("[B] Visa bokningsinformation och gästlista\n");
            Console.WriteLine("[C] Sök efter en gäst\n");
            Console.WriteLine("[D] Avsluta programmet");
        }

        public static void CreateGuest(List<Guest> guestList)
        {
            Console.Write("Ange gästens namn: ");
            string guestName = Console.ReadLine();

            Console.Write("Ange gästens e-postadress: ");
            string email = Console.ReadLine();

            Console.Write("Ange gästens telefonnummer: ");
            int phone = ReadInt();

            Guest newGuest = new Guest(guestName, email, phone);
            guestList.Add(newGuest);
            Console.WriteLine("Gäst tillagd!");
        }

        public static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning, försök igen.");
                }
            }
        }

        public static void printGuestList(List<Guest> guestList)
        {
            if (guestList.Count == 0)
            {
                Console.WriteLine("Inga gäster är registrerade.");
            }
            else
            {
                Console.WriteLine("Registrerade gäster:");
                foreach (Guest guest in guestList)
                {
                    Console.WriteLine($"Namn: {guest.guestName}, E-post: {guest.email}, Telefonnummer: {guest.phone}");
                }
            }
        }

        public static void searchForGuest(List<Guest> guestList)
        {
            Console.Write("Skriv in gästens namn du söker efter: ");
            string searchName = Console.ReadLine().ToUpper();
            var foundGuest = guestList.Find(guest => guest.guestName.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundGuest != null)
            {
                Console.WriteLine("\nGäst hittad:");
                Console.WriteLine($"Namn: {foundGuest.guestName}");
                Console.WriteLine($"E-post: {foundGuest.email}");
                Console.WriteLine($"Telefonnummer: {foundGuest.phone}");
            }
            else
            {
                Console.WriteLine("\nGästen hittades inte.");
            }
        }
    }
}