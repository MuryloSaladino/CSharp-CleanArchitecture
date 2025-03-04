using AutoMapper;
using MediatR;
using Skills.Application.Common.Exceptions;
using Skills.Domain.Common;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Domain.Repository.SkillsRepository;
using Skills.Domain.Repository.UsersRepository;

namespace Skills.Application.Features.Skills.Create;

public sealed class CreateSkillHandler(
    ISkillsRepository skillsRepository,
    IUsersRepository userRepository,
    IUnitOfWork unitOfWork,
    UserSession session,
    IMapper mapper
) : IRequestHandler<CreateSkillRequest, CreateSkillResponse>
{
    private readonly ISkillsRepository skillsRepository = skillsRepository;
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly UserSession session = session;
    private readonly IMapper mapper = mapper;

    public async Task<CreateSkillResponse> Handle(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = mapper.Map<Skill>(request);
        var userId = session.Id ?? throw new AppException("Unauthorized", 401);
        var user = await userRepository.Get(userId, cancellationToken)
            ?? throw new AppException("User not found", 404);
        
        skill.User = user;
        skill.UserId = userId;
            
        skillsRepository.Create(skill);
        
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateSkillResponse>(skill);
    }
}