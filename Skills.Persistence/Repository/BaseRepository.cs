using Microsoft.EntityFrameworkCore;
using Skills.Application.Repository;
using Skills.Domain.Common;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository;

public class BaseRepository<TEntity>(SkillsContext skillsContext) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly SkillsContext context = skillsContext;


    public void Create(TEntity entity)
        => context.Add(entity);

    public void Update(TEntity entity)
        => context.Update(entity);

    public Task<TEntity?> Get(Guid id, CancellationToken cancellationToken)
        => context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        => context.Set<TEntity>().ToListAsync(cancellationToken);

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.Now;
        context.Update(entity);
    }
}