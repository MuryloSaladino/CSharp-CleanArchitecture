using Domain.Common;

namespace Domain.Entities;

public class Skill : BaseEntity
{
    public required string Name { get; set; }
}