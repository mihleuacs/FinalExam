using FinalExam.Models.DTOs.CreateDtos;
using FinalExam.Models.DTOs.UpdateDtos;
using FinalExam.Models.DTOs;
using FinalExam.Services.Interface;
using FinalExam.Services.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController (IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientRepository.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }


        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientRepository.AddAsync(clientDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientDto clientto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingClient = await _clientRepository.GetByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.FirstName = clientto.FirstName;
            existingClient.LastName = clientto.LastName;
            existingClient.DOB = clientto.DOB;
            existingClient.Address = clientto.Address;
            existingClient.Nationality = clientto.Nationality;
            existingClient.RentalStart = clientto.RentalStart;
            existingClient.RentalEnd = clientto.RentalEnd;
            existingClient.CarId = clientto.CarId;

            await _clientRepository.UpdateAsync(existingClient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
