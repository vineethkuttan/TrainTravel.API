﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTravel.API.Model.Domain
{
    public class BookingsData
    {
        public Guid Id { get; set; }
        public string TrainNumber { get; set; }
        public string TrainName { get; set; }
        public string DepartureTime { get; set; }
        public string DepartFrom { get; set; }
        public string DepartDayCount { get; set; }
        public int Distance { get; set; }
        public string ArrivalTime { get; set; }
        public string ArrivalDayCount { get; set; }
        public string Destination { get; set; }
        public string DestinationHaltTime { get; set; }
        public string UserId { get; set; } // Foreign key to IdentityDbContext's Id
        [ForeignKey("UserId")]
        public TrainTravelUser User { get; set; }
    }
}
