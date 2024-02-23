using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTravel.API.Model.Domain
{
    public class TrainTimeTableData
    {
       
        [Key]
        [Column(Order = 1)]
        public int trainNumber { get; set; }
        [Key]
        [Column(Order = 2)]
        public string stationCode { get; set; }
        public string? trainName { get; set; }
        public TimeSpan departureTime { get; set; }
        public string? haltTime { get; set; }
        public string? dayCount { get; set; }
        public int distance { get; set; }
        public TimeSpan arrivalTime { get; set; }
        public string? stationName { get; set; }
        [ForeignKey("trainNumber")]
        public TrainInfoData TrainInfoData { get; set; }
    }
}
