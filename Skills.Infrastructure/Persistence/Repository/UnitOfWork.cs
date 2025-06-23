using Skills.Domain.Repository;
using Skills.Infrastructure.Persistence.Context;

namespace Skills.Infrastructure.Persistence.Repository;

public class UnitOfWork(SkillsContext ctx) : IUnitOfWork
{
    public Task Save(CancellationToken cancellationToken)
        => ctx.SaveChangesAsync(cancellationToken);
}