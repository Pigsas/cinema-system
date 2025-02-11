using System;
using CinemaSystem;

namespace CinemaSystem.Models;

public class Reservation
{
    public int Id { get; set; }
    public Movie Movie { get; set; }
    public Seat Seat { get; set; }
    public string CustomerName { get; set; }
}
