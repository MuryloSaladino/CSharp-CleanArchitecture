using FluentValidation;

namespace Skills.Application.Features.Users.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Username).MinimumLength(3);
        RuleFor(u => u.Password).MinimumLength(8);
    }
}