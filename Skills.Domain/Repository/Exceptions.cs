using System.Linq.Expressions;
using Skills.Domain.Common;
using Skills.Domain.Enums;

namespace Skills.Domain.Repository;

public class EntityNotFoundException<TEntity>()
    : BaseException($"{typeof(TEntity).Name} not found.", ExceptionCode.NotFound)
        where TEntity : BaseEntity;

public class DuplicatedEntityException<TEntity>(Expression<Func<TEntity, object>> propertySelector) 
    : BaseException($"An entity of type '{typeof(TEntity).Name}' with the same '{GetPropertyName(propertySelector)}' already exists.", ExceptionCode.Conflict)
        where TEntity : BaseEntity
{
    private static string GetPropertyName(Expression<Func<TEntity, object>> expression)
        => expression.Body switch
        {
            MemberExpression member => member.Member.Name,
            UnaryExpression { Operand: MemberExpression member } => member.Member.Name,
            _ => throw new ArgumentException("Invalid property selector expression")
        };
}