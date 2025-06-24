using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Modules.Users.Find;

public class FindUserMapper : Profile
{
    public FindUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}