using MediatR;

namespace Skills.Application.Usecases.Users.FindBySkill;

public sealed record FindUsersBySkillRequest(
    string? SkillName
) : IRequest<List<FindUsersBySkillResponse>>;