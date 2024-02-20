using AutoMapper;
using TrainTravel.API.Model.Domain;
using TrainTravel.API.Model.DTO;

namespace TrainTravel.API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<QueryTimeTable, AvailableResponseDto>();
            CreateMap<StationInfoData, StationInfoDto>();
            CreateMap<BookingRequestDto, BookingsData>().ReverseMap();
            CreateMap<BookingRequestDto, TicketData>().ReverseMap();
            CreateMap<PassengerRequestDto, PassengerData>().ReverseMap();
            CreateMap<PassengerResponseDto, PassengerData>().ReverseMap();
        }
    }
}
