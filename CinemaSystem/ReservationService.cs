using System;
using System.Collections.Generic;
using System.IO;
using CinemaSystem.Models;

namespace CinemaSystem;

public class ReservationService
{
    private readonly int _maxRow = 5;
    private readonly int _maxSeatNumberPerRow = 5;

    private readonly string _reservationDatabase = "..//..//..//reservations.db";
    //ReserveSeat


    public Dictionary<string, Seat> GetAvailableSeats(string movieTitle)
    {
        Dictionary<string, Seat> reservedSeats = GetReservedSeatsByMovie(movieTitle);
        Dictionary<string, Seat> availableSeats = new Dictionary<string, Seat>();

        for (int i = 1; i <= _maxRow; i++)
        {
            for (int j = 1; j <= _maxSeatNumberPerRow; j++)
            {
                string seatIdentification = $"{i}-{j}";
                if (!reservedSeats.ContainsKey(seatIdentification))
                {
                    Seat seat = new Seat()
                    {
                        Row = i,
                        Number = j
                    };
                    availableSeats.Add(seatIdentification, seat);
                }
            }
        }

        return availableSeats;
    }

    private Dictionary<string, Seat> GetReservedSeatsByMovie(string movieTitle)
    {
        Dictionary<string, Seat> seats = new Dictionary<string, Seat>();

        foreach (Reservation reservation in GetReservations())
        {
            if (reservation.Movie.Title.Equals(movieTitle, StringComparison.OrdinalIgnoreCase))
            {
                string seatIdentification = $"{reservation.Seat.Row}-{reservation.Seat.Number}";

                seats.Add(seatIdentification, reservation.Seat);
            }
        }

        return seats;
    }

    public List<Reservation> GetReservations()
    {
        MovieService movieService = new MovieService();
        List<Reservation> reservations = new List<Reservation>();

        using (StreamReader sr = new StreamReader(_reservationDatabase))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                //id|movie_id|row|seat_number|customer_name
                string[] explodedLine = line.Split("|");

                Movie movie;
                try
                {
                    movie = movieService.GetOneById(int.Parse(explodedLine[1]));
                }
                catch (Exception)
                {
                    continue;
                }

                Seat seat = new Seat()
                {
                    Row = int.Parse(explodedLine[2]),
                    Number = int.Parse(explodedLine[3]),
                    IsReserved = true,
                };

                Reservation reservation = new Reservation()
                {
                    Id = int.Parse(explodedLine[0]),
                    Movie = movie,
                    Seat = seat,
                    CustomerName = explodedLine[4]
                };

                reservations.Add(reservation);
            }
        }

        return reservations;
    }


}
