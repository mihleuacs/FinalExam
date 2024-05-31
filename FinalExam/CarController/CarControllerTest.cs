using FinalExam.Controllers;
using FinalExam.Models.Domain;
using FinalExam.Models.DTOs.CreateDtos;
using FinalExam.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarControllerTest
{
    public class CarControllerTest
    {
        [Fact]
        public async Task GetCars_ReturnsOkResult()
        {
            var mockRepository = new Mock<ICarRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Car>());
            var controller = new CarController(mockRepository.Object);


            var result = await controller.GetCars() as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetCar_WithValidId_ReturnsOkResult()
        {

            var carId = 1;
            var mockRepository = new Mock<ICarRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(carId))
                .ReturnsAsync(new Car());
            var controller = new CarController(mockRepository.Object);


            var result = await controller.GetCar(carId) as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task CreateCar_WithValidModel_ReturnsCreatedAtActionResult()
        {

            var carDto = new CreateCarDto();
            var mockRepository = new Mock<ICarRepository>();
            var controller = new CarController(mockRepository.Object);


            var result = await controller.CreateCar(carDto) as CreatedAtActionResult;


            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
        }
    }
}