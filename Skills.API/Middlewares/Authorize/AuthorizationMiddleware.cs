using Skills.Domain.Common;
using Skills.Domain.Contracts;

namespace Skills.API.Middlewares.Authorize;

public class AuthorizationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        var requiresAuth = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>() != null;
        
        if (!requiresAuth)
        {
            await _next(context);
            return;
        }

        UserSession session = (UserSession) context.Items["UserSession"]!;
    
        if(!session.IsAdmin) 
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("{\"message\": \"Unauthorized\"}");
            return;
        }

        await _next(context);
    }
}