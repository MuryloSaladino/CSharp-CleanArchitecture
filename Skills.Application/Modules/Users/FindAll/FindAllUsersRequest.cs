using MediatR;
using Skills.Application.Pipeline.Authentication;

namespace Skills.Application.Modules.Users.FindAll;

[Authenticate(AdminOnly = true)]
public sealed record FindAllUsersRequest(
    string? SkillName
) : IRequest<List<FindAllUsersResponse>>;