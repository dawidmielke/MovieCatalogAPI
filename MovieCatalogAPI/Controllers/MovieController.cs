using Microsoft.AspNetCore.Mvc;
using MovieCatalogAPI.Models;
using System.Runtime.InteropServices;

namespace MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        public List<Movie> _movies = new List<Movie>
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
            _movies.Add(movie);
            _logger.LogInformation($"Added movie: {movie.Title}");
            return Ok();
        }

        [HttpGet("Last")]
        public IActionResult GetLastAddedMovie()
        {
           if(_movies.Count == 0)
           {
                return NotFound();
           }
            var lastMovie = _movies[_movies.Count - 1];
            return Ok(lastMovie);
        }

        [HttpGet]
        [Route("year/{year}")]
        public IActionResult GetMovieByYear(int year)
        {
            var movieByYear = _movies.FindAll(x => x.Year == year);
            if(movieByYear.Count == 0)
            {
                _logger.LogWarning($"Movie with this {year} not found");
                return NotFound();
            }
            return Ok(movieByYear);
        }

        [HttpGet]
        [Route("genre/{genre}")]
        public IActionResult GetMovieByGenre(string genre)
        {
            var movieByGenre = _movies.FindAll(x =>x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
            if (movieByGenre.Count == 0)
            {
                _logger.LogWarning($"Movie with this {genre} not found");
                return NotFound();
            }
            return Ok(movieByGenre);
        }
    }
}
