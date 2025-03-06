using AutoMapper;
using MediatR;
using Skills.Application.Common.Exceptions;
using Skills.Domain.Repository;
using Skills.Domain.Repository.UsersRepository;

namespace Skills.Application.Features.Users.Promote;

public sealed class PromoteUserHandler(
    IUsersRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<PromoteUserRequest, PromoteUserResponse>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;


    public async Task<PromoteUserResponse> Handle(
        PromoteUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.Get(Guid.Parse(request.Id), cancellationToken)
            ?? throw new AppException("User not found", 404);

        user.IsAdmin = true;
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<PromoteUserResponse>(user);
    }
}