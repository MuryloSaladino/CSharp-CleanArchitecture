using FluentValidation;

namespace Skills.Application.Features.Skills.Create;

public class CreateSkillValidator : AbstractValidator<CreateSkillRequest>
{
    public CreateSkillValidator()
    {
        RuleFor(s => s.Name).MinimumLength(3).MaximumLength(25);
        RuleFor(s => s.Level).GreaterThan(0).LessThan(6);
    }
}