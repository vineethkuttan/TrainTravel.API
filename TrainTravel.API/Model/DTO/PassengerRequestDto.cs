using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.DTO
{
    public class PassengerRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int age { get; set; }
        public int? preference { get; set; }
    }
}
