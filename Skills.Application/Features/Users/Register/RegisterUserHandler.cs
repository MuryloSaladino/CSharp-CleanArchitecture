using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Skills.Application.Repository;
using Skills.Application.Repository.UserRepository;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Users.Register;

public sealed class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserReponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    private readonly PasswordHasher<User> hasher;

    public RegisterUserHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper,
            PasswordHasher<User> passwordHasher)
    {
        this.unitOfWork = unitOfWork;
        this.userRepository = userRepository;
        this.mapper = mapper;
        this.hasher = passwordHasher;
    }

    public async Task<RegisterUserReponse> Handle(
            RegisterUserRequest request, 
            CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        user.Password = hasher.HashPassword(user, user.Password);
        userRepository.Create(user);
        await unitOfWork.Save(cancellationToken);
        
        return mapper.Map<RegisterUserReponse>(user); 
    }
}