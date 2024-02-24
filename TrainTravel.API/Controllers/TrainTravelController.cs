using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainTravel.API.CustomActionFilters;
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
        //POST :/api/TrainTravel/Available?filterOn
        [HttpPost]
        [Route("Available")]
        [ValidateModel]
        public async Task<IActionResult> GetAvailable([FromBody] AvailableRequestDto availableRequestDto, [FromQuery] string? arrivalTime, [FromQuery] string? departureTime, 
            [FromQuery] bool? sortByArrivalTime, [FromQuery] bool? sortByDepartTime,
            [FromQuery] bool? arrivalTimeGreaterthan=true,[FromQuery] bool? departureTimeGreaterthan = true,
            [FromQuery] int pageNumber=1,[FromQuery] int pageSize = 1000
            )
        {            
            int DayOfWeek = (int)availableRequestDto.Date.DayOfWeek;
            var arrivalTimeSpan = new TimeSpan();
            var departureTimeSpan = new TimeSpan();
            if (arrivalTime != null)
            {
                TimeSpan.TryParse(arrivalTime, out arrivalTimeSpan);
                logger.LogInformation($"Given Value for arrivalTime:{arrivalTime} and parsed Timespan:{arrivalTimeSpan}");
            }
            if (departureTime != null)
            {
                TimeSpan.TryParse(departureTime, out departureTimeSpan);
                logger.LogInformation($"Given Value for departureTime:{departureTime} and parsed Timespan:{departureTimeSpan}");
            }
            var result = await timeTableRepository.GetAllTimeTableAsync(availableRequestDto.FromStationCode,availableRequestDto.ToStationCode,
                availableRequestDto.Date,pageNumber, pageSize,
                arrivalTimeSpan, departureTimeSpan, arrivalTimeGreaterthan,departureTimeGreaterthan ,
                sortByArrivalTime, sortByDepartTime);
            if (result == null)
            {
                return NotFound();
            }                
            logger.LogInformation($"The Count of available val from DB {result.Count} and count of available val send in response {result.Count}");
            return Ok(mapper.Map<List<AvailableResponseDto>>(result));            
        }

        //Get :/api/TrainTravel/ListAll
        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> GetStationList()
        {           
            var result = await timeTableRepository.GetStationListAsync();
            if (result == null)
            {
                return NotFound();
            }
            logger.LogInformation($"The Count of return Station Info from DB {result.Count}");
            return Ok(mapper.Map<List<StationInfoDto>>(result));            
        }
    }
}
