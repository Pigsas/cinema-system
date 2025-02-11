using System;

namespace CinemaSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Select option:\n1.Get movie list\n2.Get free seats for movie\n3.Reserve seat\n4.List all reservations\n5.Exit");
                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":



                            break;
                        case "2":
                            Console.WriteLine("Enter movie title:");
                            string movieTitle =Console.ReadLine().Trim().ToLower();

                            break;
                        case "3":
                            Console.WriteLine("Enter movie title:");
                            string movieTitle2 = Console.ReadLine().Trim().ToLower();

                            Console.WriteLine("Enter seat row:");
                            string seatRowRaw = Console.ReadLine();
                            int seatRow = Convert.ToInt32(seatRowRaw);

                            Console.WriteLine("Enter seat number:");
                            string seatNumberRaw = Console.ReadLine();
                            int seatNumber = Convert.ToInt32(seatNumberRaw);

                            Console.WriteLine("Enter your name:");
                            string customerName = Console.ReadLine();

                            break;
                        case "4":

                            break;
                        case "5":
                            keepGoing = false;
                            break;
                        default:
                            Console.WriteLine("Option does not exits");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}