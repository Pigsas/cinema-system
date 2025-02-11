using System;

namespace CinemaSystem.Models;

public class Seat
{
    public int Row { get; set; }
    public int Number { get; set; }
    public bool IsReserved { get; set; } = false;
}
