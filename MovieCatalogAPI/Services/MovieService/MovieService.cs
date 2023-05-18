using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {

        public static List<Movie> _movies = new List<Movie>
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

        //public MovieService()
        //{
        //    _movies = new List<Movie>();
        //}

        public void AddMovie(Movie model)
        {
            _movies.Add(model);
        }

        public Movie GetLastAddedMovie()
        {
            if(_movies.Count == 0) 
                return null;
            return _movies.Last();
        }

        public List<Movie> GetMovieByGenre(string genre)
        {
            return _movies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Movie> GetMovieByYear(int year)
        {
            return _movies.Where(m => m.Year == year).ToList();
        }
    }
}
