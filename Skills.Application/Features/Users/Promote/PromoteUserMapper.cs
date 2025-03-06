using AutoMapper;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Users.Promote;

public sealed class PromoteUserMapper : Profile
{
    public PromoteUserMapper()
    {
        CreateMap<User, PromoteUserResponse>();
    }
}