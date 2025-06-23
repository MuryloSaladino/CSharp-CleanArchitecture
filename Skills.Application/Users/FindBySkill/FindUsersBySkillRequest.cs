using MediatR;
using Skills.Application.Common.Behaviors;

namespace Skills.Application.Users.FindBySkill;

[Authenticate(AdminOnly = true)]
public sealed record FindUsersBySkillRequest(
    string? SkillName
) : IRequest<List<FindUsersBySkillResponse>>;