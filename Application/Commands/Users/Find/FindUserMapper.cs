using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Users.Find;

public class FindUserMapper : Profile
{
    public FindUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}