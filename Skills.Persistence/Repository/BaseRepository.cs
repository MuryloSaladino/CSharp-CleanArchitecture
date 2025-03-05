using Microsoft.EntityFrameworkCore;
using Skills.Domain.Common;
using Skills.Domain.Repository;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository;

public class BaseRepository<TEntity>(SkillsContext skillsContext) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly SkillsContext context = skillsContext;
    protected readonly DbSet<TEntity> dbSet = skillsContext.Set<TEntity>();

    public void Create(TEntity entity)
        => context.Add(entity);

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        context.Update(entity);
    }

    public Task<TEntity?> Get(Guid id, CancellationToken cancellationToken)
        => context
            .Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        => context
            .Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .ToListAsync(cancellationToken);

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        context.Update(entity);
    }
    
    public Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => dbSet.AnyAsync(e => 
            EF.Property<Guid>(e, "Id") == id && 
            EF.Property<Guid?>(e, "DeletedAt") == null, 
        cancellationToken);
}