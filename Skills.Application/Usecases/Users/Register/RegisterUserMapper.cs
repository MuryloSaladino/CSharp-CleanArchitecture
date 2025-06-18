using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Usecases.Users.Register;

public sealed class RegisterUserMapper : Profile
{
    public RegisterUserMapper()
    {
        CreateMap<RegisterUserRequest, User>();
        CreateMap<User, RegisterUserResponse>();
    }
}