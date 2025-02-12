using System;
using CinemaSystem;
using CinemaSystem.Models;

namespace TestCinemaSystem;

public class ReservationService_Test
{
    public ReservationService_Test()
    {
        string[] movies = [
            "1|Echoes of Tomorrow|130",
            "2|Whispers in the Fog|98"
        ];
        File.WriteAllLines("..//..//..//movie.txt", movies);
        
        string[] reservations = [
            "1|1|1|3|Kazimieras",
            "2|1|5|2|Linas"
        ];
        File.WriteAllLines("..//..//..//reservations.db", reservations);
    }

    [Fact]
    public void Test_ReservationService_GetAvailableSeats_IsCorrect()
    {
        ReservationService reservationService= new ReservationService();

        Dictionary<string, Seat> availableSeats = reservationService.GetAvailableSeats("Echoes of Tomorrow");

        Assert.Equal(23, availableSeats.Count);
        Assert.False(availableSeats.ContainsKey("1-3"));
        Assert.False(availableSeats.ContainsKey("5-2"));
    }

    [Fact]
    public void Test_ReservationService_GetAvailableSeats_ThrowException()
    {
        ReservationService reservationService= new ReservationService();

        Assert.Throws<Exception>(() => reservationService.GetAvailableSeats("Nera filmo"));
    }

    [Fact]
    public void Test_ReservationService_GetAvailableSeats_ThrowException_OnEpty()
    {
        ReservationService reservationService= new ReservationService();

        Assert.Throws<Exception>(() => reservationService.GetAvailableSeats(""));
    }

    [Fact]
    public void Test_ReservationService_GetReservations_IsCorrect()
    {
        ReservationService reservationService= new ReservationService();

        List<Reservation> reservations = reservationService.GetReservations();

        Assert.Equal(2, reservations.Count);
        Assert.Equal(1, reservations[0].Id);
        Assert.Equal(1, reservations[0].Movie.Id);
        Assert.Equal("Echoes of Tomorrow", reservations[0].Movie.Title);
        Assert.Equal(130, reservations[0].Movie.Duration);
        Assert.Equal(1, reservations[0].Seat.Row);
        Assert.Equal(3, reservations[0].Seat.Number);
        Assert.True(reservations[0].Seat.IsReserved);
        Assert.Equal("Kazimieras", reservations[0].CustomerName);
    }

    [Fact]
    public void Test_ReservationService_ReserveSeat_IsCorrect()
    {
        ReservationService reservationService= new ReservationService();

        reservationService.ReserveSeat(
            "Echoes of Tomorrow",
            1,
            1,
            "Petras"
        );

        List<Reservation> reservations = reservationService.GetReservations();
        int last = reservations.Count - 1;

        Assert.Equal(3, reservations.Count);
        Assert.Equal(3, reservations[last].Id);
        Assert.Equal(1, reservations[last].Movie.Id);
        Assert.Equal("Echoes of Tomorrow", reservations[last].Movie.Title);
        Assert.Equal(130, reservations[last].Movie.Duration);
        Assert.Equal(1, reservations[last].Seat.Row);
        Assert.Equal(1, reservations[last].Seat.Number);
        Assert.True(reservations[last].Seat.IsReserved);
        Assert.Equal("Petras", reservations[last].CustomerName);
    }

    [Theory]
    [InlineData("Echoes of Tomorrow",1, 3,"Petras")]
    [InlineData("",1, 3,"Petras")]
    [InlineData("Echoes of Tomorrow",6, 3,"Petras")]
    [InlineData("Echoes of Tomorrow",1, 6,"Petras")]
    [InlineData("Echoes of Tomorrow",1, 3,"")]
    public void Test_ReservationService_ReserveSeat_ThowsException(
        string title,
        int row,
        int seat,
        string customerName
    )
    {
        ReservationService reservationService= new ReservationService();

        Assert.Throws<Exception>(() => reservationService.ReserveSeat(
           title,
           row,
           seat,
           customerName
        ));
    }
}
