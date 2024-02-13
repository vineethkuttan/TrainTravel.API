using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.DTO
{
    public class AvailableRequestDto
    {
        [Required]
        public string FromStationCode { get; set; }
        [Required]
        public string ToStationCode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
