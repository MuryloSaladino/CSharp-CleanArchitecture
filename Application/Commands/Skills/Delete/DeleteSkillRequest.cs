using MediatR;

namespace Application.Commands.Skills.Delete;

public sealed record DeleteSkillRequest(
    Guid SkillId
) : IRequest;