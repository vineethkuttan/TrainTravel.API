using Microsoft.AspNetCore.Mvc;
using TrainTravel.API.Controllers;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface ITimeTableRepository
    {
        Task<List<QueryTimeTable>> GetAllTimeTableAsync(string FromCode,string ToCode,
            DateTime DayOfWeek,
            int pageNumber, int pageSize, TimeSpan? arrivalTime = null,
            TimeSpan? departureTime = null, bool? arrivalTimeGreaterthan = true,bool? departureTimeGreaterthan = true,
            bool? sortByArrivalTime=null, bool? sortByDepartTime=null);
        Task<List<StationInfoData>> GetStationListAsync();
    }
}
