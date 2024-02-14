using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.DTO
{
    public class AvailableRequestDto
    {
        [Required]
        [MaxLength(4)]
        public string FromStationCode { get; set; }
        [Required]
        [MaxLength(4)]
        public string ToStationCode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
