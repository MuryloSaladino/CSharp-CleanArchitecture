using AutoMapper;
using MediatR;
using Skills.Application.Common.Exceptions;
using Skills.Domain.Common;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Domain.Repository.SkillsRepository;

namespace Skills.Application.Features.Skills.Edit;

public sealed class EditSKillHandler(
    ISkillsRepository skillsRepository,
    IUnitOfWork unitOfWork,
    UserSession session,
    IMapper mapper
) : IRequestHandler<EditSkillRequest, EditSkillResponse>
{
    private readonly ISkillsRepository skillsRepository = skillsRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly UserSession session = session;
    private readonly IMapper mapper = mapper;

    public async Task<EditSkillResponse> Handle(
        EditSkillRequest request, CancellationToken cancellationToken)
    {
        Guid userId = session.Id ?? throw new AppException("Unauthorized", 401);

        bool exists = await skillsRepository.ExistsForUser(
            Guid.Parse(request.Id!), 
            userId, 
            cancellationToken
        );
        if(!exists) {
            throw new AppException("Skill not found", 404);
        }

        var skill = mapper.Map<Skill>(request);
        skill.Id = Guid.Parse(request.Id!);
        skill.UserId = userId;
        skillsRepository.Update(skill);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<EditSkillResponse>(skill);
    }
}