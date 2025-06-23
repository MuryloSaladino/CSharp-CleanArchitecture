using FluentValidation;

namespace Skills.Application.Users.FindBySkill;

public class FindUsersBySkillValidator : AbstractValidator<FindUsersBySkillRequest>
{
    public FindUsersBySkillValidator()
    {
        RuleFor(r => r.SkillName).MaximumLength(25);
    }
}