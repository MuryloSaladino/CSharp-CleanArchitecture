using FluentValidation;

namespace Skills.Application.Features.Users.Promote;

public class PromoteUserValidator : AbstractValidator<PromoteUserRequest>
{
    public PromoteUserValidator()
    {
        RuleFor(u => u.Id).Must(id => Guid.TryParse(id, out _));
    }
}