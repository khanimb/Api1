using Api1.Dtos;
using FluentValidation;

namespace Api1.Validations
{
    public class RegisterDtoValidation: AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                 .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                                    .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        }
    }
}
