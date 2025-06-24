using MediatR;
using Skills.Application.Pipeline.Authentication;

namespace Skills.Application.Modules.Skills.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateSkillRequest(
    string Name
) : IRequest<CreateSkillResponse>;