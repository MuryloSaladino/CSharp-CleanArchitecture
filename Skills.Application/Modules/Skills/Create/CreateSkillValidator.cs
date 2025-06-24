using FluentValidation;

namespace Skills.Application.Modules.Skills.Create;

public class CreateSkillValidator : AbstractValidator<CreateSkillRequest>
{
    public CreateSkillValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .MaximumLength(35);
    }
}
