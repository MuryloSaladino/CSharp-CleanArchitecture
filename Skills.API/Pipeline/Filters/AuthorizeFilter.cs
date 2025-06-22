using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using Skills.Domain.Exceptions;
using Skills.Application.Validation;

namespace Skills.API.Pipeline.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute() : Attribute;

public class AuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizeAttribute = context.ActionDescriptor.EndpointMetadata
            .OfType<AuthorizeAttribute>()
            .FirstOrDefault();

        if (authorizeAttribute is null)
            return;

        try
        {
            var httpContext = context.HttpContext;
            var requestSession = httpContext.RequestServices.GetRequiredService<UserSession>();
            requestSession.GetLoggedAdminOrThrow();
        }
        catch (AppException e)
        {
            var result = new ContentResult
            {
                Content = JsonSerializer.Serialize(new
                {
                    statusCode = e.StatusCode,
                    message = e.Message,
                    details = e.Details,
                }),
                StatusCode = (int)e.StatusCode,
                ContentType = "application/json"
            };
            context.Result = result;
        }
    }
}
