using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieCatalogAPI.Controllers;
using MovieCatalogAPI.Models;

namespace MovieTests
{
    public class MovieControllerTest
    {
        [Fact]
        public void AddMovie_ReturnOkResult()
        {
            var loggerMock = new Mock<ILogger<MovieController>>();
            var controller = new MovieController(loggerMock.Object);
            var movie = new Movie
            {
                Id = 3,
                Year = 2020,
                Title = "Inception",
                Genre = "Science Fiction"
            };

            var result = controller.AddMovie(movie);

            Assert.IsType<OkResult>(result);
        }

        //[Fact]
        //public void GetLastAddedMovie_WithEmptyMovies_ReturnsOkResult()
        //{
        //    var loggerMock = new Mock<ILogger<MovieController>>();
        //    var controller = new MovieController(loggerMock.Object);
        //    var movie = new Movie
        //    {
        //        Id = 4,
        //        Year = 1999,
        //        Title = "Fight Club",
        //        Genre = "Thriller"
        //    };
        //    var addMovie = controller.AddMovie(movie);
        //    var result = controller.GetLastAddedMovie(movie);

        //    Assert.IsType<OkResult>(result);
        //}

        [Fact]
        public void GetMovieByYear_WithInvalidYear_ReturnsNotFoundResult()
        {
            var loggerMock = new Mock<ILogger<MovieController>>();
            var controller = new MovieController(loggerMock.Object);

            var result = controller.GetMovieByYear(-2022);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetMovieByGenre_WithInvalidGenre_ReturnsNotFoundResult()
        {
            var loggerMock = new Mock<ILogger<MovieController>>();
            var controller = new MovieController(loggerMock.Object);

            var result = controller.GetMovieByGenre("afdsfsad");

            Assert.IsType<NotFoundResult>(result);
        }
    }
}