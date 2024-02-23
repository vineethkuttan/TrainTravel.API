using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrainTravel.API.CustomActionFilters;
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
        private readonly ITicketRepository ticketRepository;
        private readonly IPassengerRepository passengerRepository;

        public BookingController(ILogger<BookingController> logger, IMapper mapper,IBookRepository bookRepository,
            ITicketRepository ticketRepository,IPassengerRepository passengerRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.bookRepository = bookRepository;
            this.ticketRepository = ticketRepository;
            this.passengerRepository = passengerRepository;
        }
        //POST :/api/booking/book
        [HttpPost]
        [Route("book")]
        [ValidateModel]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> BookTrain([FromBody] BookingRequestDto bookingRequestDto)
        {
            try
            {             
                var response =new List<PassengerResponseDto>();
                var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var bookingsDomainModel = mapper.Map<BookingsData>(bookingRequestDto);
                bookingsDomainModel.UserId = user;
                var bookingResult = await bookRepository.BookAsync(bookingsDomainModel);
                if(bookingResult!=null && bookingResult.Id != Guid.Empty) 
                {
                    var ticketDomainModel = mapper.Map<TicketData>(bookingRequestDto);
                    ticketDomainModel.BookingId= bookingResult.Id;
                    var ticketResult = await ticketRepository.CreateTicketAsync(ticketDomainModel);           
                    if (ticketResult != null && ticketResult.Id != Guid.Empty)
                    {
                        foreach (var passenger in bookingRequestDto.passengerRequests)
                        {
                            var passengerDomainModel = mapper.Map<PassengerData>(passenger);
                            passengerDomainModel.TicketId=ticketDomainModel.Id;
                            var passengerResult=await passengerRepository.CreatePassengerAsync(passengerDomainModel);
                            if(passengerResult!=null)
                            {

                                response.Add(mapper.Map<PassengerResponseDto>(passengerResult));
                            }
                        }
                    }
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
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetUserBookings()
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if(id == null)
                {
                    return BadRequest("Invalid user");
                }
                var bookingResult = await bookRepository.GetAllBookingForUserAsync(id);
                var response = new List<BookingResponseDto>();
                if (bookingResult != null && bookingResult.Count > 0)
                {
                    foreach (var booking in bookingResult)
                    {
                        if (booking != null && booking.Id != Guid.Empty)
                        {
                            var Tickets = await ticketRepository.GetAllTicketForBookingAsync(booking.Id);
                            if (Tickets != null && Tickets.Count > 0)
                            {
                                foreach (var ticket in Tickets)
                                {
                                    if (ticket != null && ticket.Id != Guid.Empty)
                                    {
                                        var passengers = await passengerRepository.GetAllPassengersTicketAsync(ticket.Id);
                                        if (passengers != null && passengers.Count > 0)
                                        {
                                            response.Add(new BookingResponseDto
                                            {
                                                TrainName = booking.TrainName,
                                                DepartureTime = booking.DepartureTime,
                                                DepartFrom = booking.DepartFrom,
                                                DepartDayCount = booking.DepartDayCount,
                                                Distance = booking.Distance,
                                                ArrivalTime = booking.ArrivalTime,
                                                ArrivalDayCount = booking.ArrivalDayCount,
                                                Destination = booking.Destination,
                                                DestinationHaltTime = booking.DestinationHaltTime,
                                                TicketId = ticket.Id,
                                                Email = ticket.Email,
                                                BookingDate = ticket.BookingDate,
                                                PhoneNumber = ticket.PhoneNumber,
                                                passengerResponse = mapper.Map<List<PassengerResponseDto>>(passengers)
                                            });

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
              
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }


        //Delete : https://localhost:port/api/booking/{id}
        [HttpDelete]
        [Route("cancelTicket/{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> CancelTicket([FromRoute] Guid id)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var passengerRemoved = await passengerRepository.DeletePassengerAsync(id);
            if (passengerRemoved != null && passengerRemoved.TicketId != Guid.Empty)
            {
                var passengerRemovedTicketId = passengerRemoved.TicketId;
                var passengerForTicket = await passengerRepository.GetAllPassengersTicketAsync(passengerRemovedTicketId);
                if (passengerForTicket != null && passengerForTicket.Count == 0)
                {
                    var ticketRemoved = await ticketRepository.DeleteTicketAsync(passengerRemovedTicketId);
                    if (ticketRemoved != null && ticketRemoved.BookingId != Guid.Empty)
                    {
                        var bookingDomain = await bookRepository.DeleteBookingAsync(ticketRemoved.BookingId);
                        if (bookingDomain != null)
                        {
                            return Ok("Successfully Cancelled the Ticket");
                        }
                    }
                    else
                    {
                        return Ok("Deleted the ticket but not the booking");
                    }
                }
                else if (passengerForTicket != null && passengerForTicket.Count > 0)
                {
                    return Ok("Sucessfully Deleted a Single Passenger");
                }
            }
            return NotFound();     
        }
    }
}
