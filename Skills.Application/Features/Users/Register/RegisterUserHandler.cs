using AutoMapper;
using MediatR;
using Skills.Domain.Contracts;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Domain.Repository.UsersRepository;

namespace Skills.Application.Features.Users.Register;

public sealed class RegisterUserHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IPasswordEncrypter encrypter = encrypter;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;


    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        user.Password = encrypter.Hash(user);
        userRepository.Create(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}