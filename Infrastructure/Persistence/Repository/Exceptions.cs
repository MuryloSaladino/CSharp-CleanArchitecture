using System.Linq.Expressions;
using Domain.Common;
using Domain.Enums;

namespace Infrastructure.Persistence.Repository;

public class DatabaseException(string message)
    : BaseException(message, ExceptionCode.InternalServerError);

public class EntityNotFoundException<TEntity>()
    : BaseException($"{typeof(TEntity).Name} not found.", ExceptionCode.NotFound)
        where TEntity : class;
        
public class EntityNotFoundException()
    : BaseException("Entity not found.", ExceptionCode.NotFound);


public class DuplicatedEntityException<TEntity>(Expression<Func<TEntity, object>> propertySelector)
    : BaseException($"An entity of type '{typeof(TEntity).Name}' with the same '{GetPropertyName(propertySelector)}' already exists.", ExceptionCode.Conflict)
        where TEntity : class
{
    private static string GetPropertyName(Expression<Func<TEntity, object>> expression)
        => expression.Body switch
        {
            MemberExpression member => member.Member.Name,
            UnaryExpression { Operand: MemberExpression member } => member.Member.Name,
            _ => throw new ArgumentException("Invalid property selector expression")
        };
}

public class DuplicatedEntityException(string message)
    : BaseException(message, ExceptionCode.Conflict);