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
        public async Task<List<QueryTimeTable>> GetAllTimeTableAsync(string FromCode, string ToCode)
        {
            var trainDataQuery = from t1 in dbContext.TrainTimeTableData
                       join t2 in dbContext.TrainTimeTableData on t1.trainNumber equals t2.trainNumber
                       where t1.departureTime != "--" &&
                             t1.stationCode == FromCode &&
                             t2.stationCode == ToCode &&
                             ((string.Compare(t1.departureTime, t2.departureTime)<0 && t1.dayCount == t2.dayCount) ||
                              string.Compare(t1.dayCount,t2.dayCount)<0)
                       select new 
                       {
                           TrainNumber = t1.trainNumber,
                           TrainName = t1.trainName,
                           DepartureTime = t1.departureTime,
                           DepartFrom = t1.stationName,
                           DepartDayCount = t1.dayCount,
                           Distance = int.Parse(t2.distance) - int.Parse(t1.distance),
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
                                 RunningDays = new List<bool>
                                 {
                                     String.Equals(ti.trainRunsOnSun, "y", StringComparison.OrdinalIgnoreCase),
                                     String.Equals(ti.trainRunsOnMon, "y", StringComparison.OrdinalIgnoreCase),
                                     String.Equals(ti.trainRunsOnTue, "y", StringComparison.OrdinalIgnoreCase),
                                     String.Equals(ti.trainRunsOnWed, "y", StringComparison.OrdinalIgnoreCase),
                                     String.Equals(ti.trainRunsOnThu, "y", StringComparison.OrdinalIgnoreCase),
                                     String.Equals(ti.trainRunsOnFri, "y", StringComparison.OrdinalIgnoreCase),
                                     String.Equals(ti.trainRunsOnSat, "y", StringComparison.OrdinalIgnoreCase)
                                 }
                                 
                             };

            return await tDataQuery.ToListAsync();
        }

        public async Task<List<StationInfoData>> GetStationListAsync()
        {
            return await dbContext.StationInfoData.ToListAsync();
        }
    }
}
