namespace FinalExam.Models.DTOs.CreateDtos
{
    public class CreateClientDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public DateTime RentalStart { get; set; }

        public DateTime RentalEnd { get; set; }

        public int CarId { get; set; }
    }
}
