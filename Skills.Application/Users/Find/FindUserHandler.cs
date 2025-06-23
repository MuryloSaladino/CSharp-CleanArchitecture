using AutoMapper;
using MediatR;
using Skills.Domain.Exceptions;
using Skills.Domain.Repository.Users;

namespace Skills.Application.Users.Find;

public sealed class FindUserHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUserRequest, FindUserResponse>
{
    public async Task<FindUserResponse> Handle(
        FindUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Find(request.UserId, cancellationToken)
            ?? throw new AppException(ExceptionCode.NotFound, ExceptionMessages.NotFound.User);

        return mapper.Map<FindUserResponse>(user);
    }
}