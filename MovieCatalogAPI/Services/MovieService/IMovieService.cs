using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Services.MovieService
{
    public interface IMovieService
    {
        List<Movie> AddMovie(Movie model);
        Movie GetLastAddedMovie(int id);
        Movie GetMovieByYear(int year);
        Movie GetMovieByGenre(string genre);
        
    }
}
