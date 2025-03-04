using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Skills.Create;

public sealed class CreateSkillMapper : Profile
{
    public CreateSkillMapper()
    {
        CreateMap<CreateSkillRequest, Skill>();
        CreateMap<Skill, CreateSkillResponse>();
    }
}