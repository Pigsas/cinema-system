using System;
using System.IO;

namespace CinemaSystem
{
    class Program
    {
        static void Main()
        {
            ReviewMovieList();
        }

        static void ReviewMovieList()
        {
            string[] movieList = File.ReadAllLines("..//..//..//movie.txt");
            foreach (string movie in movieList)
            {
                Console.WriteLine(movie);
            }
        }
    }
}