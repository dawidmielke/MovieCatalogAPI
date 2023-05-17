using Microsoft.AspNetCore.Mvc;
using MovieCatalogAPI.Models;
using MovieCatalogAPI.Services.MovieService;

namespace MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
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

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            movies.Add(movie);
            return Ok(movies);
        }

        [HttpGet("last")]
        public IActionResult GetLastAddedMovie()
        {
            if (movies.Count == 0)
            {
                return NotFound();
            }
            var lastMovie = movies[movies.Count - 1];
            return Ok(lastMovie);
        }

        [HttpGet]
        [Route("year/{year}")]
        public IActionResult GetMovieByYear(int year)
        {
            var movieByYear = movies.FindAll(x => x.Year == year);
            return Ok(movieByYear);
        }

        [HttpGet]
        [Route("genre/{genre}")]
        public IActionResult GetMovieByGenre(string genre)
        {
            var movieByGenre = movies.FindAll(x => x.Genre == genre);
            return Ok(movieByGenre);
        }
    }
}
