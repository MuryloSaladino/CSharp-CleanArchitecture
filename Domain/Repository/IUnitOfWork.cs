namespace Domain.Repository;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}