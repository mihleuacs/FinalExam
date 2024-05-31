using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models.Domain
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public int Year { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
