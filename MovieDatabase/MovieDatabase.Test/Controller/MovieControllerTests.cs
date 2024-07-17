using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MovieDatabase.Controllers;
using MovieDatabase.Dto;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Test.Controller
{
    public class MovieControllerTests
    {
        private readonly IMovieRepository _MovieRepository;
        private readonly IWorkerRepository _WorkerRepository;
        private readonly IMapper _Mapper;

        public MovieControllerTests()
        {
            _MovieRepository = A.Fake<IMovieRepository>();
            _WorkerRepository = A.Fake<IWorkerRepository>();
            _Mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void MovieController_GetMovies_ReturnsOk()
        {
            // Arrange
            var movies = A.Fake<ICollection<MovieDto>>();
            var movieList = A.Fake<List<MovieDto>>();
            A.CallTo(() => _Mapper.Map<List<MovieDto>>(movies)).Returns(movieList);
            var controller = new MovieController(_MovieRepository, _Mapper, _WorkerRepository);

            // Act
            var result = controller.GetMovies();

            // Assert
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void MovieController_CreateMovie_ReturnsOk()
        {
            // Arrange
            var movie = A.Fake<Movie>();
            var movieCreate = A.Fake<MovieDto>();
            var director = A.Fake<Worker>();
            director.Role = Role.Director;
            var controller = new MovieController(_MovieRepository, _Mapper, _WorkerRepository);

            A.CallTo(() => _Mapper.Map<Movie>(movieCreate))
                .Returns(movie);

            A.CallTo(() => _MovieRepository.GetMoviesTrimToUpper(movieCreate)).Returns(null);


            A.CallTo(() => _MovieRepository.CreateMovie(movie))
                .Returns(true);

            A.CallTo(() => _WorkerRepository.GetWorkerById(director.Id)).Returns(director);

            // Act
            var result = controller.CreateMovie(movieCreate);

            // Assert
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void MovieController_UpdateMovie_ReturnsOk()
        {
            // Arrange
            var movie = A.Fake<Movie>();
            var movieUpdate = A.Fake<MovieDto>();
            var director = A.Fake<Worker>();
            director.Role = Role.Director;
            var controller = new MovieController(_MovieRepository, _Mapper, _WorkerRepository);

            A.CallTo(() => _Mapper.Map<Movie>(movieUpdate))
                .Returns(movie);


            A.CallTo(() => _MovieRepository.UpdateMovie(movie))
                .Returns(true);

            A.CallTo(() => _WorkerRepository.GetWorkerById(director.Id)).Returns(director);

            // Act
            var result = controller.UpdateMovie(movie.Id, movieUpdate);

            // Assert
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void MovieController_DeleteMovie_ReturnsOk()
        {
            // Arrange
            var movie = A.Fake<Movie>();
            var movieUpdate = A.Fake<MovieDto>();;
            var controller = new MovieController(_MovieRepository, _Mapper, _WorkerRepository);

            A.CallTo(() => _MovieRepository.GetMovieById(movie.Id)).Returns(movie);
            A.CallTo(() => _MovieRepository.DeleteMovie(movie)).Returns(true);

            // Act
            var result = controller.DeleteMovie(movie.Id);

            // Assert
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
