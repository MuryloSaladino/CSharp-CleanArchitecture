using MediatR;

namespace Skills.Application.Features.Skills.Create;

public sealed record CreateSkillRequest(
    string Name,
    int Level
) : IRequest<CreateSkillResponse>;