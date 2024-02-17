using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface IPassengerRepository
    {
        Task<List<PassengerData>> GetAllPassengersTicketAsync(Guid TicketId);
        Task<PassengerData?> GetPassengerIdAsync(Guid PassengerId);
        Task<PassengerData> CreatePassengerAsync(PassengerData PassengerData);
        Task<PassengerData?> DeletePassengerAsync(Guid PassengerId);
    }
}
