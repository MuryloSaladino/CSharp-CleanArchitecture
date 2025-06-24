using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Modules.Skills.Create;

public class CreateSkillMapper : Profile
{
    public CreateSkillMapper()
    {
        CreateMap<CreateSkillRequest, Skill>();
        CreateMap<Skill, CreateSkillResponse>();
    }
}