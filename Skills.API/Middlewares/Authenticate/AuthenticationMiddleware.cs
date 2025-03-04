using Skills.Domain.Contracts;

namespace Skills.API.Middlewares.Authenticate;

public class AuthenticationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        var requiresAuth = endpoint?.Metadata.GetMetadata<AuthenticateAttribute>() != null;
        
        if (!requiresAuth)
        {
            await _next(context);
            return;
        }

        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("{\"message\": \"Missing or invalid Authorization header\"}");
            return;
        }

        var token = authHeader.Split(" ")[1];

        try
        {
            var authService = context.RequestServices.GetRequiredService<IAuthenticator>();
            var userSession = authService.ExtractToken(token);

            context.Items["UserSession"] = userSession;

            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("{\"message\": \"Invalid token\"}");
        }
    }
}