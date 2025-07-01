using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Skills.Create;

public class CreateSkillMapper : Profile
{
    public CreateSkillMapper()
    {
        CreateMap<CreateSkillRequest, Skill>();
        CreateMap<Skill, CreateSkillResponse>();
    }
}