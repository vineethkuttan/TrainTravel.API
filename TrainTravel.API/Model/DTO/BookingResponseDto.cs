namespace TrainTravel.API.Model.DTO
{
    public class BookingResponseDto
    {
        public DateTime DateOfBirth { get; set; }
        public string TrainName { get; set; }
        public string DepartureTime { get; set; }
        public string DepartFrom { get; set; }
        public string DepartDayCount { get; set; }
        public int Distance { get; set; }
        public string ArrivalTime { get; set; }
        public string ArrivalDayCount { get; set; }
        public string Destination { get; set; }
        public string DestinationHaltTime { get; set; }
        public string UserId { get; set; }
        public Guid TicketId { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public string PhoneNumber { get; set; }
        public Guid PaasengerId { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public int? preference { get; set; }
    }
}
