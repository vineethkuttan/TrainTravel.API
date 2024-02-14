using Microsoft.EntityFrameworkCore;
using System;
using TrainTravel.API.Data;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly TrainTravelDbContext dbContext;

        public BookRepository(TrainTravelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BookingsData> CreateAsync(BookingsData BookingData)
        {
            await dbContext.BookingsData.AddAsync(BookingData);
            await dbContext.SaveChangesAsync();
            return BookingData;
        }

        public async Task<BookingsData?> DeleteAsync(Guid id)
        {
            var existingBooking = await dbContext.BookingsData.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBooking == null)
            {
                return null;
            }
            dbContext.BookingsData.Remove(existingBooking);
            dbContext.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<List<BookingsData>> GetAllAsync(string userId)
        {
            var bookings = dbContext.BookingsData.Include(b=>b.User).AsQueryable();
            bookings = bookings.Where(b => b.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase));
            return await bookings.ToListAsync();
        }

        public async Task<BookingsData> GetByIdAsync(Guid id)
        {
            return await dbContext.BookingsData.Include(b => b.User).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
