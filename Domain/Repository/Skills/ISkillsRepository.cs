using Domain.Entities;

namespace Domain.Repository.Skills;

public record SkillFilter : BaseEntityFilter
{
    public string? NamePattern { get; set; }
}

public interface ISkillsRepository : IBaseRepository<Skill, SkillFilter>;