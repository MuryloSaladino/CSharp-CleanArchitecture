using MediatR;
using Skills.Application.Common.Exceptions;
using Skills.Domain.Repository;
using Skills.Domain.Repository.SkillsRepository;

namespace Skills.Application.Features.Skills.Delete;

public sealed class DeleteSkillHandler(
    ISkillsRepository skillsRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteSkillRequest, DeleteSkillResponse>
{
    private readonly ISkillsRepository skillsRepository = skillsRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteSkillResponse> Handle(
        DeleteSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = await skillsRepository.Get(Guid.Parse(request.Id), cancellationToken) 
            ?? throw new AppException("Skill not found", 404);

        skillsRepository.Delete(skill);

        await unitOfWork.Save(cancellationToken);

        return new DeleteSkillResponse();
    }
}