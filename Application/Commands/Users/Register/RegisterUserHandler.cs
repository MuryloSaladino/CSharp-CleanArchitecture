using AutoMapper;
using MediatR;
using Domain.Identity;
using Domain.Entities;
using Domain.Repository;
using Domain.Repository.Users;

namespace Application.Commands.Users.Register;

public sealed class RegisterUserHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        user.Password = encrypter.Hash(user.Password);

        userRepository.Create(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}