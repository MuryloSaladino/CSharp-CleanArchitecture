using FluentValidation;
using Domain.Repository.Users;

namespace Application.Commands.Users.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator(IUsersRepository usersRepository)
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(35)
            .MustAsync(async (username, cancellationToken) =>
                !await usersRepository.Exists(new() { Username = username }, cancellationToken)
            );

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}