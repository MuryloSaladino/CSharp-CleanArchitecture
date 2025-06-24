using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Modules.Users.FindAll;

public class FindAllUsersMapper : Profile
{
    public FindAllUsersMapper()
    {
        CreateMap<User, FindAllUsersResponse>();
    }
}