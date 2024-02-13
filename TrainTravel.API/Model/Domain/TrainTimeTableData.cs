using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTravel.API.Model.Domain
{
    public class TrainTimeTableData
    {
        public string? trainNumber { get; set; }
        public string? trainName { get; set; }
        public string? departureTime {  get; set; }
        public string? stationCode {  get; set; }
        public string? haltTime {  get; set; }
        public string? dayCount {  get; set; }
        public string? distance {  get; set; }
        public string? arrivalTime {  get; set; }
        public string? stationName {  get; set; }
    }
}
