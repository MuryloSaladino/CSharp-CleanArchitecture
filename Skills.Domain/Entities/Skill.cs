namespace Skills.Domain.Entities;

using Common;

public class Skill : BaseEntity
{
    public required string Name { get; set; }
    public int Level { get; set; }
}