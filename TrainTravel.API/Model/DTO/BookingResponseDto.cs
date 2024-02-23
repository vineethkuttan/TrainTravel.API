namespace TrainTravel.API.Model.DTO
{
    public class BookingResponseDto
    {
        public string TrainName { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string DepartFrom { get; set; }
        public string DepartDayCount { get; set; }
        public int Distance { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string ArrivalDayCount { get; set; }
        public string Destination { get; set; }
        public string DestinationHaltTime { get; set; }
        public Guid TicketId { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public string PhoneNumber { get; set; }

        public List<PassengerResponseDto> passengerResponse { get; set; }
    }
}
