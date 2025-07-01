using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Users.FindMany;

public class FindAllUsersMapper : Profile
{
    public FindAllUsersMapper()
    {
        CreateMap<User, FindManyUsersResponse>();
    }
}