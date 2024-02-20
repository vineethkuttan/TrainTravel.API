using FluentValidation;
using TrainTravel.API.Model.DTO;

namespace TrainTravel.API.Validators
{
    public class RegisterRequestDtoValidator: AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Name).MinimumLength(1);
            RuleFor(x => x.Username).EmailAddress();
            RuleFor(x=>x.Gender).NotEmpty();
            RuleFor(x=>x.PhoneNumber).MaximumLength(10);
            RuleFor(x=>x.PhoneNumber).MinimumLength(10);
        }
    }
}
