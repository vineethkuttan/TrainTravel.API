using TrainTravel.API.Controllers;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface ITimeTableRepository
    {
        Task<List<QueryTimeTable>> GetAllTimeTableAsync(string FromCode,string ToCode);
        Task<List<StationInfoData>> GetStationListAsync();
    }
}
