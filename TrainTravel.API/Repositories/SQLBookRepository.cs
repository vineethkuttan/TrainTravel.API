using Microsoft.EntityFrameworkCore;
using System;
using TrainTravel.API.Data;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly TrainTravelDbContext dbContext;

        public SQLBookRepository(TrainTravelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BookingsData> BookAsync(BookingsData BookingData)
        {
            await dbContext.BookingsData.AddAsync(BookingData);
            await dbContext.SaveChangesAsync();
            return BookingData;
        }

        public async Task<BookingsData?> DeleteBookingAsync(Guid id)
        {
            var existingBooking = await dbContext.BookingsData.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBooking == null)
            {
                return null;
            }
            dbContext.BookingsData.Remove(existingBooking);
            await dbContext.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<List<BookingsData>> GetAllBookingForUserAsync(string userId)
        {
            var bookings = dbContext.BookingsData.Include(b => b.User).Where(b => string.Equals(b.User.Id, userId));
            return await bookings.ToListAsync();
        }

        public async Task<BookingsData?> GetBookingByIdAsync(Guid id)
        {
            return await dbContext.BookingsData.Include(b => b.User).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
