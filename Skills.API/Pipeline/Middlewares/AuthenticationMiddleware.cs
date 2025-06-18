using System.Text.Json;
using Skills.API.Constants;
using Skills.Application.Validation;
using Skills.Domain.Contracts;

namespace Skills.API.Pipeline.Middlewares;

public class AuthenticationMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, CancellationToken cancellationToken)
    {
        var accessToken = context.Request.Cookies[Cookies.AccessToken];

        if (accessToken is string token)
        {
            try
            {
                var authService = context.RequestServices.GetRequiredService<IAuthenticator>();
                var scopedSession = context.RequestServices.GetRequiredService<UserSession>();
                
                var sessionPayload = await authService.ExtractUserFromToken(token, cancellationToken);
                scopedSession.User = sessionPayload;
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                string message = JsonSerializer.Serialize(new { message = e.Message });
                await context.Response.WriteAsync(message, cancellationToken);
            }
        }

        await next(context);
    }
}