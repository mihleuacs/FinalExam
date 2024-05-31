using FinalExam.Controllers;
using FinalExam.Models.Domain;
using FinalExam.Models.DTOs.CreateDtos;
using FinalExam.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitTest
{
    public class ClientControllerTest
    {
        [Fact]
        public async Task GetClient_ReturnsOkResult()
        {
            var mockRepository = new Mock<IClientRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Client>());
            var controller = new ClientController(mockRepository.Object);


            var result = await controller.GetClients() as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetClient_WithValidId_ReturnsOkResult()
        {

            var clientId = 1;
            var mockRepository = new Mock<IClientRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(clientId))
                .ReturnsAsync(new Client());
            var controller = new ClientController(mockRepository.Object);


            var result = await controller.GetClient(clientId) as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task CreateClient_WithValidModel_ReturnsOkResult()
        {

            var clientDto = new CreateClientDto();
            var mockRepository = new Mock<IClientRepository>();
            var controller = new ClientController(mockRepository.Object);


            var result = await controller.CreateClient(clientDto) as OkResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
