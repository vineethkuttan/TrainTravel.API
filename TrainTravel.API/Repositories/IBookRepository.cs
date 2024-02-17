using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookingsData>> GetAllBookingForUserAsync(string userId);
        Task<BookingsData> GetBookingByIdAsync(Guid id);
        Task<BookingsData?> BookAsync(BookingsData BookingData);
        Task<BookingsData?> DeleteBookingAsync(Guid id);
    }
}
