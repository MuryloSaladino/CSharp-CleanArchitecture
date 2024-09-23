using FluentValidation;

namespace Skills.Application.Features.Users.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Username).NotEmpty();
        RuleFor(u => u.Password).MinimumLength(8);
    }
}