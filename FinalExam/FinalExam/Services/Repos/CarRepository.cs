using FinalExam.Data;
using FinalExam.Models.Domain;
using FinalExam.Models.DTOs;
using FinalExam.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Services.Repos
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _carDbContext;
        public CarRepository(CarDbContext carDbContext)     
        {
            _carDbContext = carDbContext;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _carDbContext.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _carDbContext.Cars.ToListAsync();
        }

        public async Task AddAsync(CarDto carDto)
        {
            var car = new Car
            {
                LicensePlate = carDto.LicensePlate,
                Model = carDto.Model,
                Manufacturer = carDto.Manufacturer,
                Year = carDto.Year,
               
            };

            await _carDbContext.Cars.AddAsync(car);
            await _carDbContext.SaveChangesAsync();
        }


        public async Task<Car> UpdateAsync(Car car)
        {
            _carDbContext.Entry(car).State = EntityState.Modified;
            await _carDbContext.SaveChangesAsync();
            return car;
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _carDbContext.Cars.FindAsync(id);
            if (car != null)
            {
                _carDbContext.Cars.Remove(car);
                await _carDbContext.SaveChangesAsync();
            }
        }
    }
}
