using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Skills.Edit;

public sealed class EditSkillMapper : Profile
{
    public EditSkillMapper()
    {
        CreateMap<EditSkillRequest, Skill>();
        CreateMap<Skill, EditSkillResponse>();
    }
}