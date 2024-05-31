using FinalExam.Data;
using FinalExam.Models.Domain;
using FinalExam.Models.DTOs;
using FinalExam.Models.DTOs.CreateDtos;
using FinalExam.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Services.Repos
{
    public class ClientRepository : IClientRepository
    {
        private readonly CarDbContext _carDbContext;
        public ClientRepository(CarDbContext carDbContext) 
        {
            _carDbContext = carDbContext;
        }
        public async Task<Client> GetByIdAsync(int id)
        {
            return await _carDbContext.Clients.FindAsync(id);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _carDbContext.Clients.ToListAsync();
        }

        public async Task AddAsync(CreateClientDto clientDto)
        {
            var Client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                DOB = clientDto.DOB,
                Address = clientDto.Address,
                Nationality = clientDto.Nationality,
                RentalStart = clientDto.RentalStart,
                RentalEnd = clientDto.RentalEnd,
                CarId = clientDto.CarId,

            };

            await _carDbContext.Clients.AddAsync(Client);
            await _carDbContext.SaveChangesAsync();
        }


        public async Task<Client> UpdateAsync(Client client)
        {
            _carDbContext.Entry(client).State = EntityState.Modified;
            await _carDbContext.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _carDbContext.Clients.FindAsync(id);
            if (client != null)
            {
                _carDbContext.Clients.Remove(client);
                await _carDbContext.SaveChangesAsync();
            }
        }

    }
}
