using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Services.MovieService
{
    public interface IMovieService
    {
        void AddMovie(Movie model);
        Movie? GetLastAddedMovie();
        List<Movie>? GetMovieByYear(int year);
        List<Movie> GetMovieByGenre(string genre);
        
    }
}
