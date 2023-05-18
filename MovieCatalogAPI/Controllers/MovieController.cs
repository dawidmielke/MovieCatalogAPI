using Microsoft.AspNetCore.Mvc;
using MovieCatalogAPI.Models;
using MovieCatalogAPI.Services.MovieService;
using System.Runtime.InteropServices;

namespace MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            _movieService.AddMovie(movie);
            return Ok();
        }

        [HttpGet("Last")]
        public async Task<IActionResult> GetLastAddedMovie()
        {
            var lastAddedMovie = _movieService.GetLastAddedMovie();
            if(lastAddedMovie == null)
            {
                return NotFound();
            }
            return Ok(lastAddedMovie);
        }

        [HttpGet]
        [Route("year/{year}")]
        public async Task<IActionResult> GetMovieByYear(int year)
        {
            var movieByYear = _movieService.GetMovieByYear(year);
            if(movieByYear == null)
            {
                return NotFound();
            }
            return Ok(movieByYear);
        }

        [HttpGet]
        [Route("genre/{genre}")]
        public async Task<IActionResult> GetMovieByGenre(string genre)
        {
            var movieByGenre = _movieService.GetMovieByGenre(genre);
            if( movieByGenre == null)
            {
                return NotFound();
            }
            return Ok(movieByGenre);
        }
    }
}
