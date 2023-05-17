using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {

        public List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Year = 2012,
                Title = "Django",
                Genre = "Western"
            },
            new Movie
            {
                Id = 2,
                Year = 2011,
                Title = "Intouchables",
                Genre = "Drama"
            }
        };

        public List<Movie> AddMovie(Movie model)
        {
            throw new NotImplementedException();
        }

        public Movie GetLastAddedMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
