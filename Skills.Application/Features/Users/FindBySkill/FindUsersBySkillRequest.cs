using MediatR;

namespace Skills.Application.Features.Users.FindBySkill;

public sealed record FindUsersBySkillRequest(
    string SkillNameFilter
) : IRequest<List<FindUsersBySkillResponse>>;