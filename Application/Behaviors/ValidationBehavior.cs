using FluentValidation;
using MediatR;
using Application.Exceptions;

namespace Application.Behaviors;

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

        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );

        var error = validationResults
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .FirstOrDefault();

        if (error is not null)
            throw new RequestValidationException(error.ErrorMessage);

        return await next();
    }
}