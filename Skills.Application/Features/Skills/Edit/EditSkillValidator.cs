using FluentValidation;

namespace Skills.Application.Features.Skills.Edit;

public class EditSkillValidator : AbstractValidator<EditSkillRequest>
{
    public EditSkillValidator()
    {
        RuleFor(s => s.Id).Must(id => Guid.TryParse(id, out _));
        RuleFor(s => s.Name).MinimumLength(3).MaximumLength(25);
        RuleFor(s => s.Level).GreaterThan(0).LessThan(6);
    }
}