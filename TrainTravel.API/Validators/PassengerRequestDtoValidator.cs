using FluentValidation;
using TrainTravel.API.Model.DTO;

namespace TrainTravel.API.Validators
{
    public class PassengerRequestDtoValidator : AbstractValidator<PassengerRequestDto>
    {
        public PassengerRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.preference).LessThan(9);
            RuleFor(x => x.preference).GreaterThanOrEqualTo(0);            
        }
    }
}
