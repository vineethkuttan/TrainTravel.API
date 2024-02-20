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
            RuleFor(x => x.DepartureTime).NotEmpty();
            RuleFor(x => x.DepartureTime).MaximumLength(5);
            RuleFor(x => x.DepartFrom).NotEmpty();
            RuleFor(x => x.DepartDayCount).NotEmpty();
            RuleFor(x => x.ArrivalTime).NotEmpty();
            RuleFor(x => x.ArrivalDayCount).NotEmpty();
            RuleFor(x => x.Destination).NotEmpty();
            RuleFor(x => x.ArrivalTime).MaximumLength(5);
            RuleFor(x => x.DestinationHaltTime).NotEmpty();
            RuleFor(x => x.DestinationHaltTime).MaximumLength(5);
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.PhoneNumber).MaximumLength(10);
            RuleFor(x => x.PhoneNumber).MinimumLength(10);
        }
    }
}
