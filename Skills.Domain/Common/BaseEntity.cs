namespace Skills.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null!;
    public DateTime? DeletedAt { get; set; } = null!;
}