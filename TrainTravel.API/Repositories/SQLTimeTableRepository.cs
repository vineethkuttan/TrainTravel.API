using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System;
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
        public async Task<List<QueryTimeTable>> GetAllTimeTableAsync(string FromCode, string ToCode,
            DateTime DayOfWeek,
            int pageNumber, int pageSize,
            TimeSpan? arrivalTime = null, TimeSpan? departureTime = null, 
            bool? arrivalTimeGreaterthan = true, bool? departureTimeGreaterthan = true,
            bool? sortByArrivalTime = true, bool? sortByDepartTime = false)
        {
            var trainDataQuery = from t1 in dbContext.TrainTimeTableData
                       join t2 in dbContext.TrainTimeTableData on t1.trainNumber equals t2.trainNumber
                       where t1.departureTime != TimeSpan.Zero &&
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
            var trainInfoData = from t1 in dbContext.TrainInfoData
                                where (DayOfWeek.DayOfWeek ==System.DayOfWeek.Sunday)?
                                        t1.trainRunsOnSun==true:
                                        (DayOfWeek.DayOfWeek == System.DayOfWeek.Monday) ?
                                        t1.trainRunsOnMon == true :
                                        (DayOfWeek.DayOfWeek == System.DayOfWeek.Tuesday) ?
                                        t1.trainRunsOnTue == true :
                                        (DayOfWeek.DayOfWeek == System.DayOfWeek.Wednesday) ?
                                        t1.trainRunsOnWed == true :
                                        (DayOfWeek.DayOfWeek == System.DayOfWeek.Thursday) ?
                                        t1.trainRunsOnThu == true :
                                        (DayOfWeek.DayOfWeek == System.DayOfWeek.Friday) ?
                                        t1.trainRunsOnFri == true :
                                        (DayOfWeek.DayOfWeek == System.DayOfWeek.Saturday) ?
                                        t1.trainRunsOnSat == true :
                                        false                                   
                                select t1;
            var tDataQuery = from td in trainDataQuery
                             join ti in trainInfoData on td.TrainNumber equals ti.trainNumber                       
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
            var result = tDataQuery.AsQueryable();

            //Filtering
            if (arrivalTime != null && arrivalTime != TimeSpan.Zero)
            {
                if (arrivalTimeGreaterthan != null && arrivalTimeGreaterthan == true)
                    result = result.Where(x => x.ArrivalTime > arrivalTime);
                else
                    result = result.Where(x => x.ArrivalTime < arrivalTime);
            }
            if (departureTime != null && departureTime != TimeSpan.Zero)
            {
                if (departureTime != null && departureTimeGreaterthan == true)
                    result = result.Where(x => x.DepartureTime > departureTime);
                else
                    result = result.Where(x => x.DepartureTime < departureTime);
            }

            //Sorting

            if (sortByArrivalTime != null)
                result = sortByArrivalTime==true ? result.OrderBy(x => x.ArrivalTime) : result.OrderByDescending(x => x.ArrivalTime);

            if(sortByDepartTime!=null)
                result = sortByDepartTime == true ? result.OrderBy(x => x.DepartureTime) : result.OrderByDescending(x => x.DepartureTime);

            //Pagination
            var skikresults = (pageNumber - 1) * pageSize;
            return await result.Skip(skikresults).Take(pageSize).ToListAsync();
        }
        public async Task<List<StationInfoData>> GetStationListAsync()
        {
            return await dbContext.StationInfoData.ToListAsync();
        }

    }
}
