using FluentValidation;
using TrainTravel.API.Model.DTO;

namespace TrainTravel.API.Validators
{
    public class BookingRequestDtoValidator : AbstractValidator<BookingRequestDto>
    {
        public BookingRequestDtoValidator()
        {
            RuleFor(x => x.TrainNumber).LessThan(83000);
            RuleFor(x => x.TrainName).NotEmpty();
            RuleFor(x => x.TrainName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.DepartureTime).InclusiveBetween(TimeSpan.Zero, TimeSpan.Parse("23:59:59"));        
            RuleFor(x => x.DepartFrom).NotEmpty();
            RuleFor(x => x.DepartDayCount).NotEmpty();
            RuleFor(x => x.ArrivalTime).NotEmpty();
            RuleFor(x => x.ArrivalDayCount).NotEmpty();
            RuleFor(x => x.Destination).NotEmpty();
            RuleFor(x => x.ArrivalTime).InclusiveBetween(TimeSpan.Zero, TimeSpan.Parse("23:59:59"));
            RuleFor(x => x.DestinationHaltTime).NotEmpty().MaximumLength(5);
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.PhoneNumber).MaximumLength(10).MinimumLength(10);
            RuleFor(x => x.passengerRequests).NotEmpty().Custom((passengerRequest, context) =>
            {
                if (passengerRequest != null && passengerRequest.Count > 5)
                {
                    context.AddFailure("Only upto 5 passengers can be booked.");
                }
            });
            
        }
    }
}
