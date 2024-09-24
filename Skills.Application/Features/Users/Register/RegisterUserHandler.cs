using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Skills.Application.Repository;
using Skills.Application.Repository.UserRepository;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Users.Register;

public sealed class RegisterUserHandler(
            PasswordHasher<User> passwordHasher,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper) 
    : IRequestHandler<RegisterUserRequest, RegisterUserReponse>
{
    private readonly IUserRepository userRepository = userRepository;
    private readonly PasswordHasher<User> hasher = passwordHasher;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;


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