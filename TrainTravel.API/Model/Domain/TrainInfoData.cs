using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.Domain
{
    public class TrainInfoData
    {
        [Key]
        public int trainNumber { get; set; }
        public string? trainName { get; set; }
        public bool? trainRunsOnSun { get; set; }
        public bool? trainRunsOnMon { get; set; }
        public bool? trainRunsOnTue { get; set; }
        public bool? trainRunsOnWed { get; set; }
        public bool? trainRunsOnThu { get; set; }
        public bool? trainRunsOnFri { get; set; }
        public bool? trainRunsOnSat { get; set; }        
        public string? stationFrom { get; set; }
        public string? stationTo { get; set; }

    }
}
