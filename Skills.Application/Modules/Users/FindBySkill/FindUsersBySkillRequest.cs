using MediatR;
using Skills.Application.Pipeline.Authentication;

namespace Skills.Application.Modules.Users.FindBySkill;

[Authenticate(AdminOnly = true)]
public sealed record FindUsersBySkillRequest(
    string? SkillName
) : IRequest<List<FindUsersBySkillResponse>>;