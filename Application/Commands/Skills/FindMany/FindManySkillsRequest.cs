using Domain.Repository.Skills;
using MediatR;

namespace Application.Commands.Skills.FindMany;

public sealed record FindManySkillsRequest
    : SkillFilter, IRequest<List<FindManySkillsResponse>>;
