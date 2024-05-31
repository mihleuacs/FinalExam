using FinalExam.Models.DTOs;
using FinalExam.Models.DTOs.CreateDtos;
using FinalExam.Models.DTOs.UpdateDtos;
using FinalExam.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carRepository.GetAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = new CarDto
            {
                LicensePlate = carDto.LicensePlate,
                Model = carDto.Model,
                Manufacturer = carDto.Manufacturer,
                Year = carDto.Year,
                
            };

            await _carRepository.AddAsync(car);
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] UpdateCarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCar = await _carRepository.GetByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound();
            }

           existingCar.LicensePlate = carDto.LicensePlate;
           existingCar.Model = carDto.Model;
           existingCar.Manufacturer = carDto.Manufacturer;
           existingCar.Year = carDto.Year;

            await _carRepository.UpdateAsync(existingCar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
