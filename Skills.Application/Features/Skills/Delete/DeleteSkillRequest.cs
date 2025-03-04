using MediatR;

namespace Skills.Application.Features.Skills.Delete;

public sealed record DeleteSkillRequest(
    string Id
) : IRequest<DeleteSkillResponse>; 