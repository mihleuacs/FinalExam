using FinalExam.Models.Domain;
using FinalExam.Models.DTOs;
using FinalExam.Models.DTOs.CreateDtos;
using FinalExam.Models.DTOs.UpdateDtos;

namespace FinalExam.Services.Interface
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task AddAsync(CarDto carDto);
        Task<Car> UpdateAsync(Car car);
        Task DeleteAsync(int id);
    }
}
