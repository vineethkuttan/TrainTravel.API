using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.DTO
{
    public class PassengerResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public int? preference { get; set; }
    }
}
