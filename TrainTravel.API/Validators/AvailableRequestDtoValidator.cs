using FluentValidation;
using TrainTravel.API.Model.DTO;

namespace TrainTravel.API.Validators
{
    public class AvailableRequestDtoValidator : AbstractValidator<AvailableRequestDto>
    {
        public AvailableRequestDtoValidator() 
        {
            RuleFor(x => x.FromStationCode).NotEmpty();
            RuleFor(x => x.FromStationCode).MaximumLength(4);
            RuleFor(x => x.ToStationCode).NotEmpty();
            RuleFor(x => x.ToStationCode).MaximumLength(4);
        }
    }
}
