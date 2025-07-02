using Application.Attributes;
using Domain.Enums;
using MediatR;

namespace Application.Commands.UserSkills.Acquire;

[Authenticate]
public sealed record AcquireSkillRequest(
    Guid SkillId,
    SkillLevel Level
) : IRequest;
