using Microsoft.EntityFrameworkCore;
using Npgsql;
using Domain.Repository;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository;

public class UnitOfWork(SkillsContext ctx) : IUnitOfWork
{
    public async Task Save(CancellationToken cancellationToken)
    {
        try
        {
            await ctx.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException sqlEx)
        {
            throw sqlEx.SqlState switch
            {
                PostgresErrorCodes.UniqueViolation => new DuplicatedEntityException(sqlEx.Message),
                PostgresErrorCodes.ForeignKeyViolation => new EntityNotFoundException(),
                _ => new DatabaseException(sqlEx.Message),
            };
        }
        catch (Exception e)
        {
            throw new DatabaseException(e.Message);
        }
    }
}