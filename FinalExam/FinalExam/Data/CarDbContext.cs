using FinalExam.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }


    }
}
