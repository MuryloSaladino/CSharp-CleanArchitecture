using FluentValidation;

namespace Skills.Application.Features.Skills.Delete;

public class DeleteSkillValidator : AbstractValidator<DeleteSkillRequest>
{
    public DeleteSkillValidator()
    {
        RuleFor(r => r.Id).Must(id => Guid.TryParse(id, out _));
    }
}