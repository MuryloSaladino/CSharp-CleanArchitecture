using FluentValidation;
using MediatR;
using Skills.Application.Common.Exceptions;

namespace Skills.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var failures = validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (failures.Count != 0)
        {
            var errorsDict = failures
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => string.Join(", ", g.Select(e => e.ErrorMessage))
                );

            throw new RequestValidationException(errorsDict);
        }

        return await next();
    }
}