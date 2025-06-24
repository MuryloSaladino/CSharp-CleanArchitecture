using FluentValidation;

namespace Skills.Application.Modules.Users.FindAll;

public class FindAllUsersValidator : AbstractValidator<FindAllUsersRequest>
{
    public FindAllUsersValidator()
    {
        RuleFor(r => r.SkillName).MaximumLength(25);
    }
}