using Microsoft.EntityFrameworkCore;
using Domain.Common;
using Domain.Repository;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository;

public class BaseRepository<TEntity, TFilter>(SkillsContext context) 
    : IBaseRepository<TEntity, TFilter> 
        where TEntity : class
        where TFilter : class
{
    protected SkillsContext Context = context;

    public void Create(TEntity entity)
        => Context.Add(entity);

    public void Update(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
            baseEntity.UpdatedAt = DateTime.UtcNow;
        Context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.DeletedAt = DateTime.UtcNow;
            Context.Update(baseEntity);
        }
        else Context.Remove(entity);
    }

    protected virtual IQueryable<TEntity> FilterQuery(TFilter filter)
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (typeof(BaseEntity).IsAssignableFrom(typeof(TEntity)) && filter is BaseEntityFilter baseFilter)
        {
            if (baseFilter.Id is Guid id)
                query = query.Where(e => ((BaseEntity)(object)e).Id == id);

            if (!baseFilter.IncludeDeleted)
                query = query.Where(e => ((BaseEntity)(object)e) == null);
        }

        return query;
    }

    public Task<TEntity?> FindOneOrDefault(TFilter filter, CancellationToken cancellationToken)
        => FilterQuery(filter).FirstOrDefaultAsync(cancellationToken);

    public async Task<TEntity> FindOne(TFilter filter, CancellationToken cancellationToken)
        => await FindOneOrDefault(filter, cancellationToken) ?? throw new EntityNotFoundException<TEntity>();

    public Task<List<TEntity>> FindMany(TFilter filter, CancellationToken cancellationToken)
        => FilterQuery(filter).ToListAsync(cancellationToken);

    public Task<bool> Exists(TFilter filter, CancellationToken cancellationToken)
        => FilterQuery(filter).AnyAsync(cancellationToken);
}
