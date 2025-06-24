using Skills.Domain.Common;

namespace Skills.Domain.Repository;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity?> FindOne(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> FindMany(CancellationToken cancellationToken);
    Task<bool> Exists(Guid id, CancellationToken cancellationToken);
}