using Skills.Application.Repository;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository;

public class UnitOfWork(SkillsContext ctx) : IUnitOfWork
{
    private readonly SkillsContext context = ctx;
    
    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}