using CinemaSystem;

namespace TestCinemaSystem;

public class MovieService_Test
{
    public MovieService_Test()
    {
        string[] movies = [
            "1|Echoes of Tomorrow|130",
            "2|Whispers in the Fog|98"
        ];
        File.WriteAllLines("..//..//..//movie.txt", movies);
    }

    [Fact]
    public void Test_MovieService_GetMovie_IsCorrect()
    {
        MovieService movieService= new MovieService();

        List<Movie> movieList= movieService.GetMovies();

        Assert.Equal(2, movieList.Count);
        Assert.Equal(1, movieList[0].Id);
        Assert.Equal("Echoes of Tomorrow", movieList[0].Title);
        Assert.Equal(130, movieList[0].Duration);
    }

    [Theory]
    [InlineData(1, "Echoes of Tomorrow", 130)]
    [InlineData(2, "Whispers in the Fog", 98)]
    public void Test_MovieService_GetOneById_IsCorrect(int id, string title, int duration)
    {
        MovieService movieService= new MovieService();

        Movie movie = movieService.GetOneById(id);

        Assert.Equal(id, movie.Id);
        Assert.Equal(title, movie.Title);
        Assert.Equal(duration, movie.Duration);
    }

    [Fact]
    public void Test_MovieService_GetOneById_ThrowException()
    {
        MovieService movieService= new MovieService();

        Assert.Throws<Exception>(() => movieService.GetOneById(5));
    }


    [Theory]
    [InlineData(1, "Echoes of Tomorrow", 130)]
    [InlineData(2, "Whispers in the Fog", 98)]
    public void Test_MovieService_GetOneByTitle_IsCorrect(int id, string title, int duration)
    {
        MovieService movieService= new MovieService();

        Movie movie = movieService.GetOneByTitle(title);

        Assert.Equal(id, movie.Id);
        Assert.Equal(title, movie.Title);
        Assert.Equal(duration, movie.Duration);
    }

    [Fact]
    public void Test_MovieService_GetOneByTitle_ThrowException()
    {
        MovieService movieService= new MovieService();

        Assert.Throws<Exception>(() => movieService.GetOneByTitle("Nera"));
    }

    ~MovieService_Test()
    {
        if(File.Exists("..//..//..//movie.txt"))
        {
            File.Delete("..//..//..//movie.txt");
        }
    }
}
