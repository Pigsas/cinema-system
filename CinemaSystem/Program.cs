using System;
using System.Collections.Generic;
using CinemaSystem.Models;

namespace CinemaSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieService movieService= new MovieService();
            ReservationService reservationService= new ReservationService();

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
                            List<Movie> movies = movieService.GetMovies();

                            foreach(Movie movie in movies)
                            {
                                Console.WriteLine($"{movie.Id}. \"{movie.Title}\" Duration: {movie.Duration} min.");
                            }

                            break;
                        case "2":
                            Console.WriteLine("Enter movie title:");
                            string movieTitle =Console.ReadLine().Trim().ToLower();

                            OutputMovieList(movieTitle);
                            break;
                        case "3":
                            Console.WriteLine("Enter movie title:");
                            string movieTitle2 = Console.ReadLine().Trim().ToLower();

                            OutputMovieList(movieTitle2);

                            Console.WriteLine("Enter seat row:");
                            string seatRowRaw = Console.ReadLine();
                            int seatRow = Convert.ToInt32(seatRowRaw);

                            Console.WriteLine("Enter seat number:");
                            string seatNumberRaw = Console.ReadLine();
                            int seatNumber = Convert.ToInt32(seatNumberRaw);

                            Console.WriteLine("Enter your name:");
                            string customerName = Console.ReadLine();

                            reservationService.ReserveSeat(movieTitle2, seatRow, seatNumber, customerName);
                            break;
                        case "4":
                            List<Reservation> allReservations = reservationService.GetReservations();
                                
                            foreach(Reservation reservation in allReservations)
                            {
                                Console.WriteLine($"In movie \"{reservation.Movie.Title}\" {reservation.CustomerName} has rezerved seat {reservation.Seat.Row} - {reservation.Seat.Number}");
                            }

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
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
    
        static void OutputMovieList(string movieTitle)
        {
            ReservationService reservationService= new ReservationService();
            Dictionary<string, Seat> availableSeats = reservationService.GetAvailableSeats(movieTitle);

            int lastRow = 0;
            Console.Write("Row | Available seats");
            foreach(KeyValuePair<string, Seat> seatKeyValuePair in availableSeats)
            {
                if(lastRow < seatKeyValuePair.Value.Row)
                {
                    lastRow = seatKeyValuePair.Value.Row;
                    Console.Write($"\n{seatKeyValuePair.Value.Row}   |");
                }
                Console.Write($" {seatKeyValuePair.Value.Number} |");
            }
            Console.WriteLine("");
        }
    }
}