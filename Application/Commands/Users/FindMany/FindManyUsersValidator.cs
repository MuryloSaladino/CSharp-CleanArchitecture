using FluentValidation;

namespace Application.Commands.Users.FindMany;

public class FindManyUsersValidator : AbstractValidator<FindManyUsersRequest>
{
    public FindManyUsersValidator()
    {
        RuleFor(r => r.SkillNamePattern).MaximumLength(35);
    }
}