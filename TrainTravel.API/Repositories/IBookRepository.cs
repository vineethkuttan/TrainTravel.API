using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookingsData>> GetAllAsync(string userId);
        Task<BookingsData> GetByIdAsync(Guid id);
        Task<BookingsData> CreateAsync(BookingsData BookingData);
        Task<BookingsData?> DeleteAsync(Guid id);
    }
}
