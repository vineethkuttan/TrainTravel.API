using Microsoft.EntityFrameworkCore;
using TrainTravel.API.Data;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public class SQLPassengerRepository : IPassengerRepository
    {
        private readonly TrainTravelDbContext dbContext;

        public SQLPassengerRepository(TrainTravelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<PassengerData> CreatePassengerAsync(PassengerData PassengerData)
        {
            await dbContext.PassengerData.AddAsync(PassengerData);
            return PassengerData;
        }

        public async Task<PassengerData?> DeletePassengerAsync(Guid PassengerId)
        {
            var existingPassenger = await dbContext.PassengerData.FirstOrDefaultAsync(x => x.Id == PassengerId);
            if (existingPassenger != null)
            {
                dbContext.PassengerData.Remove(existingPassenger);
                await dbContext.SaveChangesAsync();
            }
            return existingPassenger;
        }

        public async Task<List<PassengerData>> GetAllPassengersTicketAsync(Guid TicketId)
        {
            var passengers = dbContext.PassengerData.Include(b => b.Ticket).Where(b => b.TicketId == TicketId);
            return await passengers.ToListAsync();
        }

        public async Task<PassengerData?> GetPassengerIdAsync(Guid PassengerId)
        {
            var passengers = await dbContext.PassengerData.Include(b => b.Ticket).FirstOrDefaultAsync(x => x.Id == PassengerId);
            return passengers;
        }
    }
}
