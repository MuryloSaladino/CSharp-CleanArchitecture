using Skills.Domain.Common;

namespace Skills.Domain.Entities;

public class Skill : BaseEntity
{
    public required string Name { get; set; }
}