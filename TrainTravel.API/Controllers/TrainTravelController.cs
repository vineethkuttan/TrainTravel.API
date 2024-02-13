using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainTravel.API.Model.Domain;
using TrainTravel.API.Model.DTO;
using TrainTravel.API.Repositories;

namespace TrainTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainTravelController : Controller
    {
        private readonly ILogger<AuthController> logger;
        private readonly ITimeTableRepository timeTableRepository;
        private readonly IMapper mapper;

        public TrainTravelController(ILogger<AuthController> logger, ITimeTableRepository timeTableRepository,
            IMapper mapper)
        {
            this.logger = logger;
            this.timeTableRepository = timeTableRepository;
            this.mapper = mapper;
        }
        //POST :/api/TrainTravel/available
        [HttpPost]
        [Route("Available")]
        public async Task<IActionResult> Available([FromBody] AvailableRequestDto availableRequestDto)
        {
            int DayOfWeek=(int)availableRequestDto.Date.DayOfWeek;
            var result = await timeTableRepository.GetAllTimeTableAsync(availableRequestDto.FromStationCode, availableRequestDto.ToStationCode);
            var Outdata = new List<QueryTimeTable>();
            foreach ( var item in result )
            { 
                if (item.RunningDays[DayOfWeek])
                {
                    Outdata.Add(item);
                }
            }

            return Ok(mapper.Map<List<AvailableResponseDto>>(Outdata));
        }
    }
}
