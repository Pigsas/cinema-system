using System;
using System.Collections.Generic;
using System.IO;
using CinemaSystem.Models;

namespace CinemaSystem;

public class MovieService
{
    private readonly string _moviesDatabase = "..//..//..//movie.txt";

    public List<Movie> GetMovies()
    {
        List<Movie> movies = new List<Movie>();

        using (StreamReader sr = new StreamReader(_moviesDatabase))
        {
            string line;
            while((line = sr.ReadLine()) != null)
            {
                //id|titile|duration
                string[] explodedLine = line.Split("|");

                Movie movie = new Movie()
                {
                    Id = int.Parse(explodedLine[0]),
                    Title = explodedLine[1],
                    Duration = int.Parse(explodedLine[2])
                };

                movies.Add(movie);
            }
        }

        return movies;
    }

    public Movie GetOneById(int id)
    {
        List<Movie> movies = GetMovies();

        foreach(Movie movie in movies)
        {
            if(movie.Id == id)
            {
                return movie;
            }
        }

        throw new Exception("Movie was not found");
    }

    public Movie GetOneByTitle(string title)
    {
        List<Movie> movies = GetMovies();

        foreach(Movie movie in movies)
        {
            if(movie.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return movie;
            }
        }

        throw new Exception("Movie was not found");
    }



    
}
