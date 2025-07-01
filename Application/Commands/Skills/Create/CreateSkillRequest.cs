using MediatR;
using Application.Attributes;

namespace Application.Commands.Skills.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateSkillRequest(
    string Name
) : IRequest<CreateSkillResponse>;