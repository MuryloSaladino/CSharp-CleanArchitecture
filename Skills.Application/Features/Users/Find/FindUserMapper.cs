using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Users.Find;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}