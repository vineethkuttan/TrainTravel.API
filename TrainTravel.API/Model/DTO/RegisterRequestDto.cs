using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public string[] Roles { get; set; }
    }
}
