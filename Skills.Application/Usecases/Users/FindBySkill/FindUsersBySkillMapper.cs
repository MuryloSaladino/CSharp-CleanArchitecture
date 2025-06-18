using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Usecases.Users.FindBySkill;

public class FindUsersBySkillMapper : Profile
{
    public FindUsersBySkillMapper()
    {
        CreateMap<User, FindUsersBySkillResponse>();
    }
}