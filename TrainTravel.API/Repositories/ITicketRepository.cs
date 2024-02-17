using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface ITicketRepository
    {
        Task<List<TicketData>> GetAllTicketForBookingAsync(Guid bookingId);
        Task<TicketData> GetTicketIdAsync(Guid TicketId);
        Task<TicketData> CreateTicketAsync(TicketData TicketData);
        Task<TicketData?> DeleteTicketAsync(Guid TicketId);
    }
}
