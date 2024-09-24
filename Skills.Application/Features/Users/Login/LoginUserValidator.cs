using FluentValidation;

namespace Skills.Application.Features.Users.Login;

public class UserLoginValidator : AbstractValidator<LoginUserRequest>
{
    public UserLoginValidator()
    {
        RuleFor(u => u.Username).NotEmpty();
        RuleFor(u => u.Password).NotEmpty();
    }
}