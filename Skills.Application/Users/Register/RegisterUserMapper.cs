using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Users.Register;

public sealed class RegisterUserMapper : Profile
{
    public RegisterUserMapper()
    {
        CreateMap<RegisterUserRequest, User>();
        CreateMap<User, RegisterUserResponse>();
    }
}