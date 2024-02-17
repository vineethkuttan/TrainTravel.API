using Microsoft.EntityFrameworkCore;
using TrainTravel.API.Data;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public class SQLTicketRepository : ITicketRepository
    {
        private readonly TrainTravelDbContext dbContext;

        public SQLTicketRepository(TrainTravelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TicketData> CreateTicketAsync(TicketData TicketData)
        {
            await dbContext.TicketData.AddAsync(TicketData);
            await dbContext.SaveChangesAsync();
            return TicketData;
        }

        public async Task<TicketData?> DeleteTicketAsync(Guid TicketId)
        {
            var existingTicket = await dbContext.TicketData.FirstOrDefaultAsync(x => x.Id == TicketId);
            if (existingTicket != null)
            {
                dbContext.TicketData.Remove(existingTicket);
                await dbContext.SaveChangesAsync();
            }
            return existingTicket;
        }

        public async Task<List<TicketData>> GetAllTicketForBookingAsync(Guid bookingId)
        {
            var ticketForBooking = dbContext.TicketData.Include(x => x.Booking).Where(b => b.BookingId == bookingId);
            return await ticketForBooking.ToListAsync();
        }

        public async Task<TicketData> GetTicketIdAsync(Guid TicketId)
        {
            return await dbContext.TicketData.FirstOrDefaultAsync(x => x.Id == TicketId);
        }
    }
}
