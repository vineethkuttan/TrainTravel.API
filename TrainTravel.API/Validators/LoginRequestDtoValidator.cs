using FluentValidation;
using TrainTravel.API.Model.DTO;

namespace TrainTravel.API.Validators
{
    public class LoginRequestDtoValidator:AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.Username).EmailAddress();
        }
    }
}
