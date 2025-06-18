using Skills.Domain.Repository;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository;

public class UnitOfWork(SkillsContext ctx) : IUnitOfWork
{
    public Task Save(CancellationToken cancellationToken)
        => ctx.SaveChangesAsync(cancellationToken);
}