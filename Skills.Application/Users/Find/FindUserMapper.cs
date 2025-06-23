using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Users.Find;

public class FindUserMapper : Profile
{
    public FindUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}