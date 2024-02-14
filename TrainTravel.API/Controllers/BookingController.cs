using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrainTravel.API.Model.Domain;
using TrainTravel.API.Model.DTO;
using TrainTravel.API.Repositories;

namespace TrainTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> logger;
        private readonly IMapper mapper;

        public BookingController(ILogger<BookingController> logger, IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }
        //POST :/api/booking/book
        [HttpPost]
        [Route("book")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> BookTrain([FromBody] BookingRequestDto bookingRequestDto)
        {
            try
            {             
                var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var bookingsDomainModel = mapper.Map<BookingsData>(bookingRequestDto);
                bookingsDomainModel.UserId = user;

                return Ok("All good");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
