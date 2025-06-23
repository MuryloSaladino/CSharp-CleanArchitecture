using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Users.FindBySkill;

public class FindUsersBySkillMapper : Profile
{
    public FindUsersBySkillMapper()
    {
        CreateMap<User, FindUsersBySkillResponse>();
    }
}