using System.ComponentModel.DataAnnotations;

namespace FinalExam.Models.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
       
        public string LicensePlate { get; set; }
       
        public string Model { get; set; }
      
        public string Manufacturer { get; set; }
      
        public int Year { get; set; }
    }
}
