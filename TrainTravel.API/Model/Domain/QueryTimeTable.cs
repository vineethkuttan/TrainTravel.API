﻿namespace TrainTravel.API.Model.Domain
{
    public class QueryTimeTable
    {
        public int TrainNumber { get; set; }
        public string? TrainName { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string? DepartFrom { get; set; }
        public string? DepartDayCount { get; set; }
        public int Distance { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string? ArrivalDayCount { get; set; }
        public string? Destination { get; set; }
        public string? DestinationHaltTime { get; set; }
        public List<bool?>? RunningDays { get; set; }
    }
}
