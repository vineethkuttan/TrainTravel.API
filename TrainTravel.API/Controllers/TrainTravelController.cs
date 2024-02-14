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
        //POST :/api/TrainTravel/Available
        [HttpPost]
        [Route("Available")]
        public async Task<IActionResult> GetAvailable([FromBody] AvailableRequestDto availableRequestDto)
        {
            try
            {
                int DayOfWeek = (int)availableRequestDto.Date.DayOfWeek;
                var result = await timeTableRepository.GetAllTimeTableAsync(availableRequestDto.FromStationCode, availableRequestDto.ToStationCode);
                if (result == null)
                {
                    return NotFound();
                }
                var Outdata = new List<QueryTimeTable>();
                foreach (var item in result)
                {
                    if (item.RunningDays[DayOfWeek])
                    {
                        Outdata.Add(item);
                    }
                }
                logger.LogInformation($"The Count of available val from DB {result.Count} and count of available val send in response {Outdata.Count}");
                return Ok(mapper.Map<List<AvailableResponseDto>>(Outdata));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //Get :/api/TrainTravel/ListAll
        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> GetStationList()
        {
            try
            {
                var result = await timeTableRepository.GetStationListAsync();
                if (result == null)
                {
                    return NotFound();
                }
                logger.LogInformation($"The Count of return Station Info from DB {result.Count}");
                return Ok(mapper.Map<List<StationInfoDto>>(result));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
