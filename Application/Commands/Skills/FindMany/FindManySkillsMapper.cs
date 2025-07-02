using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Skills.FindMany;

public class FindManySkillsMapper : Profile
{
    protected FindManySkillsMapper()
    {
        CreateMap<Skill, FindManySkillsResponse>();
    }
}
