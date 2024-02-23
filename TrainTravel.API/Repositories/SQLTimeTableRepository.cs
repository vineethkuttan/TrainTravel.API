using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrainTravel.API.Controllers;
using TrainTravel.API.Data;
using TrainTravel.API.Model.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TrainTravel.API.Repositories
{
    public class SQLTimeTableRepository : ITimeTableRepository
    {
        private readonly TrainTravelDbContext dbContext;
        private readonly ILogger<SQLTimeTableRepository> logger;

        public SQLTimeTableRepository(TrainTravelDbContext dbContext,ILogger<SQLTimeTableRepository> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task<List<QueryTimeTable>> GetAllTimeTableAsync(string FromCode, string ToCode, TimeSpan? arrivalTimeLessThan = null, TimeSpan? arrivalTimeGreaterThan = null)
        {
            var trainDataQuery = from t1 in dbContext.TrainTimeTableData
                       join t2 in dbContext.TrainTimeTableData on t1.trainNumber equals t2.trainNumber
                       where t1.departureTime != TimeSpan.Parse("00:00") &&
                             t1.stationCode == FromCode &&
                             t2.stationCode == ToCode &&
                             ((t1.departureTime < t2.departureTime && t1.dayCount == t2.dayCount) ||
                              string.Compare(t1.dayCount,t2.dayCount)<0)
                       select new 
                       {
                           TrainNumber = t1.trainNumber,
                           TrainName = t1.trainName,
                           DepartureTime = t1.departureTime,
                           DepartFrom = t1.stationName,
                           DepartDayCount = t1.dayCount,
                           Distance = t2.distance - t1.distance,
                           ArrivalTime = t2.arrivalTime,
                           ArrivalDayCount = t2.dayCount,
                           Destination = t2.stationName,
                           DestinationHaltTime = t2.haltTime
                       };
            var tDataQuery = from td in trainDataQuery
                             join ti in dbContext.TrainInfoData on td.TrainNumber equals ti.trainNumber                       
                             select new QueryTimeTable
                             {
                                 TrainNumber = td.TrainNumber,
                                 TrainName = td.TrainName,
                                 DepartureTime = td.DepartureTime,
                                 DepartFrom = td.DepartFrom,
                                 DepartDayCount = td.DepartDayCount,
                                 Distance = td.Distance,
                                 ArrivalTime = td.ArrivalTime,
                                 ArrivalDayCount = td.ArrivalDayCount,
                                 Destination = td.Destination,
                                 DestinationHaltTime = td.DestinationHaltTime,
                                 RunningDays = new List<bool?>
                                 {
                                     ti.trainRunsOnSun,
                                     ti.trainRunsOnMon,
                                     ti.trainRunsOnTue,
                                     ti.trainRunsOnWed,
                                     ti.trainRunsOnThu,
                                     ti.trainRunsOnFri,
                                     ti.trainRunsOnSat
                                 }
                                 
                             };

            var result =tDataQuery.AsQueryable();
            //Filtering
            if(arrivalTimeGreaterThan != null)
            {
                result = result.Where(x => x.ArrivalTime > arrivalTimeGreaterThan);
            }
            return await result.ToListAsync();
        }

        public async Task<List<StationInfoData>> GetStationListAsync()
        {
            return await dbContext.StationInfoData.ToListAsync();
        }
    }
}
