using Microsoft.AspNetCore.Mvc;
using TrainTravel.API.Controllers;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface ITimeTableRepository
    {
        Task<List<QueryTimeTable>> GetAllTimeTableAsync(string FromCode,string ToCode,TimeSpan? arrivalTimeLessThan = null, TimeSpan? arrivalTimeGreaterThan = null);
        Task<List<StationInfoData>> GetStationListAsync();
    }
}
