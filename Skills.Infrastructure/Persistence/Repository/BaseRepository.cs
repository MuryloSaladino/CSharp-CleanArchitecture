using Microsoft.EntityFrameworkCore;
using Skills.Domain.Common;
using Skills.Domain.Repository;
using Skills.Infrastructure.Persistence.Context;

namespace Skills.Infrastructure.Persistence.Repository;

public class BaseRepository<TEntity>(
    SkillsContext context
) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected SkillsContext Context = context;

    public void Create(TEntity entity)
    {
        Context.Add(entity);
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        Context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        Context.Update(entity);
    }

    public Task<TEntity?> Find(Guid id, CancellationToken cancellationToken)
        => Context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<List<TEntity>> Find(CancellationToken cancellationToken)
        => Context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .ToListAsync(cancellationToken);

    public Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => Context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .Where(entity => entity.Id == id)
            .AnyAsync(cancellationToken);
}