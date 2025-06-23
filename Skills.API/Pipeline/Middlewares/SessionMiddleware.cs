using Skills.API.Constants;

namespace Skills.API.Pipeline.Middlewares;

public class SessionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var requestAccessToken = context.Request.Cookies[Cookies.AccessToken];
        var requestRefreshToken = context.Request.Cookies[Cookies.RefreshToken];

        var session = context.RequestServices.GetRequiredService<Domain.Identity.ISessionContext>();
        session.AccessToken = requestAccessToken;
        session.RefreshToken = requestRefreshToken;

        await next(context);

        if (session.AccessToken != requestAccessToken)
            context.Response.Cookies.UpdateToken(Cookies.AccessToken, session.AccessToken, DateTime.UtcNow.AddMinutes(15));

        if (session.RefreshToken != requestRefreshToken)
            context.Response.Cookies.UpdateToken(Cookies.RefreshToken, session.RefreshToken, DateTime.UtcNow.AddDays(30));
    }
}


public static class CookiesExtensions
{
    public static void UpdateToken(this IResponseCookies cookies, string cookie, string? value, DateTime ExpiresAt)
    {
        if (value is string token)
        {
            cookies.Append(cookie, token, new CookieOptions
            {
                HttpOnly = true,
                Secure = Environment.GetEnvironmentVariable("ENV_MODE") == "prod",
                SameSite = SameSiteMode.Strict,
                Expires = ExpiresAt,
            });
        }
        else
        {
            cookies.Append(cookie, string.Empty, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
            });
        }
    }
}