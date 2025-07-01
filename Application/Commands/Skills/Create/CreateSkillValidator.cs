using FluentValidation;

namespace Application.Commands.Skills.Create;

public class CreateSkillValidator : AbstractValidator<CreateSkillRequest>
{
    public CreateSkillValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .MaximumLength(35);
    }
}
