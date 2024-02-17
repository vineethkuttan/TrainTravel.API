using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.Domain
{
    public class TrainInfoData
    {
        [Key]
        public int trainNumber { get; set; }
        public string? trainName { get; set; }
        public string? trainRunsOnSun { get; set; }
        public string? trainRunsOnMon { get; set; }
        public string? trainRunsOnTue { get; set; }
        public string? trainRunsOnWed { get; set; }
        public string? trainRunsOnThu { get; set; }
        public string? trainRunsOnFri { get; set; }
        public string? trainRunsOnSat { get; set; }        
        public string? stationFrom { get; set; }
        public string? stationTo { get; set; }

    }
}
