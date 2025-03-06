using FluentValidation;

namespace Skills.Application.Features.Users.Find;

public class FindUserValidator : AbstractValidator<FindUserRequest>
{
    public FindUserValidator()
    {
        RuleFor(u => u.Id).Must(id => Guid.TryParse(id, out _));
    }
}