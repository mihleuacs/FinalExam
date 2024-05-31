using FinalExam.Models.Domain;
using FinalExam.Models.DTOs.CreateDtos;

namespace FinalExam.Services.Interface
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int id);
        Task<List<Client>> GetAllAsync();
        Task AddAsync(CreateClientDto createClientDto);
        Task<Client> UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}
