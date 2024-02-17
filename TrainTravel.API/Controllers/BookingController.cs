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
        private readonly IBookRepository bookRepository;

        public BookingController(ILogger<BookingController> logger, IMapper mapper,IBookRepository bookRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.bookRepository = bookRepository;
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
                var bookingResult = await bookRepository.BookAsync(bookingsDomainModel);
                if(bookingResult!=null && bookingResult.Id != Guid.Empty) 
                {
                    
                }
                return Ok("");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //POST :/api/booking/book
        [HttpPost]
        [Route("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetUserBookings([FromRoute] string id)
        {
            try
            {           
                id=id.ToLower();
                var result = await bookRepository.GetAllBookingForUserAsync(id);               
                return Ok(mapper.Map<List<BookingRequestDto>>(result));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }


        //Delete : https://localhost:port/api/booking/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var bookingDomain = await bookRepository.DeleteBookingAsync(id);
            if (bookingDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BookingRequestDto>(bookingDomain));

        }
    }
}
