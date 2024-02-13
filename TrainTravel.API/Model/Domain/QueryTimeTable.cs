namespace TrainTravel.API.Model.Domain
{
    public class QueryTimeTable
    {
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
        public List<bool> RunningDays{ get; set; }
        /*public bool TrainRunsOnSun { get; set; }
        public bool TrainRunsOnMon { get; set; }
        public bool TrainRunsOnTue { get; set; }
        public bool TrainRunsOnWed { get; set; }
        public bool TrainRunsOnThu { get; set; }
        public bool TrainRunsOnFri { get; set; }
        public bool TrainRunsOnSat { get; set; }*/
    }
}
