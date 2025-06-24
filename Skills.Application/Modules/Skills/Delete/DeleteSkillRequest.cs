using MediatR;

namespace Skills.Application.Modules.Skills.Delete;

public sealed record DeleteSkillRequest(
    Guid SkillId
) : IRequest;