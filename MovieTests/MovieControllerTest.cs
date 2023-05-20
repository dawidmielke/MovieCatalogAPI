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

        [Fact]
        public void GetLastAddedMovie_WithMovies_ReturnsNotNullResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<MovieController>>();
            var controller = new MovieController(loggerMock.Object);
            var movies = new List<Movie>
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
            controller._movies = movies;

            // Act
            var result = controller.GetLastAddedMovie();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, movies.Count);
        }


        [Fact]
        public void GetMovieByYear_WithInvalidYear_ReturnsNotFoundResult()
        {
            var loggerMock = new Mock<ILogger<MovieController>>();
            var controller = new MovieController(loggerMock.Object);

            var result = controller.GetMovieByYear(-2022);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetMovieByGenre_WithInvalidGenre_ReturnsNotFoundResult()
        {
            var loggerMock = new Mock<ILogger<MovieController>>();
            var controller = new MovieController(loggerMock.Object);

            var result = controller.GetMovieByGenre("afdsfsad");

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}