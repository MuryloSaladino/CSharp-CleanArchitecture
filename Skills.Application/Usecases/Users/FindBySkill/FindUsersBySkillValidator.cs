using FluentValidation;

namespace Skills.Application.Usecases.Users.FindBySkill;

public class FindUsersBySkillValidator : AbstractValidator<FindUsersBySkillRequest>
{
    public FindUsersBySkillValidator()
    {
        RuleFor(r => r.SkillName).MaximumLength(25);
    }
}