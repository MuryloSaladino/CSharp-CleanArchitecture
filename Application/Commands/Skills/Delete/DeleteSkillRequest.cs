using Application.Attributes;
using MediatR;

namespace Application.Commands.Skills.Delete;

[Authenticate(AdminOnly = true)]
public sealed record DeleteSkillRequest(
    Guid SkillId
) : IRequest;