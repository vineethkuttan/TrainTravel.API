using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.Domain
{
    public class StationInfoData
    {
        [Key]
        public string stationCode { get; set; }
        public string? stationName { get; set; }
    }
}
