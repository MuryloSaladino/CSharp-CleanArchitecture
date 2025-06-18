using AutoMapper;
using MediatR;
using Skills.Domain.Common.Exceptions;
using Skills.Domain.Contracts;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Domain.Repository.Users;

namespace Skills.Application.Usecases.Users.Register;

public sealed class RegisterUserHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        bool exists = await userRepository.ExistsByUsername(request.Username, cancellationToken);
        if(exists) throw new AppException(ExceptionCode.BadRequest, ExceptionMessages.BadRequest.ValueAlreadyTaken);

        var user = mapper.Map<User>(request);
        user.Password = encrypter.Hash(user);
        userRepository.Create(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}