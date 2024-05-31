using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models.Domain
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(400)]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public DateTime RentalStart { get; set; }
        [Required]
        public DateTime RentalEnd { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
