using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.DTO
{
    public class BookingRequestDto
    {
        [Required]
        public int TrainNumber { get; set; }
        [Required]
        public string TrainName { get; set; }
        [Required]
        public TimeSpan DepartureTime { get; set; }
        [Required]
        public string DepartFrom { get; set; }
        [Required]
        public string DepartDayCount { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        public TimeSpan ArrivalTime { get; set; }
        [Required]
        public string ArrivalDayCount { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string DestinationHaltTime { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
        public string PhoneNumber { get; set; }
        public List<PassengerRequestDto> passengerRequests { get; set; }
    }
}
