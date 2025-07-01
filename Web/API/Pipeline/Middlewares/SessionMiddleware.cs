using Domain.Identity;
using Web.API.Constants;

namespace Web.API.Pipeline.Middlewares;

public class SessionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var session = context.RequestServices.GetRequiredService<ISessionContext>();
        session.AccessToken = context.Request.Cookies[Cookies.AccessToken];
        session.RefreshToken = context.Request.Cookies[Cookies.RefreshToken];

        context.Response.OnStarting(() =>
        {
            context.UpdateTokenIfChanged(Cookies.AccessToken, session.AccessToken, DateTime.UtcNow.AddMinutes(15));
            context.UpdateTokenIfChanged(Cookies.RefreshToken, session.RefreshToken, DateTime.UtcNow.AddDays(30));

            return Task.CompletedTask;
        });

        await next(context);
    }
}

public static class CookiesExtensions
{
    public static void UpdateTokenIfChanged(this HttpContext context, string name, string? value, DateTime expiresAt)
    {
        if (value is not null)
        {
            context.Response.Cookies.Append(name, value, new CookieOptions
            {
                HttpOnly = true,
                Secure = context.Request.IsHttps,
                SameSite = SameSiteMode.Strict,
                Expires = expiresAt
            });
        }
        else
        {
            context.Response.Cookies.Append(name, string.Empty, new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(-1),
            });
        }
    }
}
