using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Users.Find;

public class FindUserMapper : Profile
{
    public FindUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}