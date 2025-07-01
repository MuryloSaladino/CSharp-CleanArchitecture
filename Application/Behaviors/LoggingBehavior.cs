using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using Domain.Identity;

namespace Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<TRequest> logger,
    ISessionContext session
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch stopwatch = new();

    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        stopwatch.Start();
        var response = await next();
        stopwatch.Stop();

        var requestName = typeof(TRequest).Name;
        var now = DateTime.UtcNow.ToString();
        var user = session.UserId == null ? "anonymous" : session.UserId.ToString();
        var took = stopwatch.ElapsedMilliseconds;

        logger.LogInformation("Successful {requestName} at {now} UTC Time for user {user} | Took {took} ms",
            requestName, now, user, took);

        return response;
    }
}