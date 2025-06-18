using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skills.API.Constants;
using Skills.Application.Usecases.Auth.Login;
using Skills.Application.Usecases.Auth.Logout;
using Skills.Application.Usecases.Auth.RefreshTokens;
using Skills.Domain.Common.Exceptions;

namespace Skills.API.Controllers;

[ApiController, Route(APIRoutes.Auth)]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost, Route("login")]
    public async Task<ActionResult> Login(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        SetTokenCookies(response.AccessToken, response.RefreshToken);
        return NoContent();
    }

    [HttpPost, Route("refresh/{userId}")]
    public async Task<ActionResult> RefreshTokens(
        [FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        if (!Request.Cookies.TryGetValue(Cookies.RefreshToken, out string? refreshToken))
            throw new AppException(ExceptionCode.Unauthorized, ExceptionMessages.Unauthorized.RefreshToken);

        var request = new RefreshTokensRequest(userId, refreshToken);
        var response = await mediator.Send(request, cancellationToken);

        SetTokenCookies(response.AccessToken, response.RefreshToken);
        return Ok();
    }

    [HttpDelete, Route("logout")]
    public async Task<ActionResult> Logout(
        [FromQuery] LogoutRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        DeleteTokenCookies();
        return NoContent();
    }

    private void SetTokenCookies(string accessToken, string refreshToken)
    {
        Response.Cookies.Append(Cookies.AccessToken, accessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = Environment.GetEnvironmentVariable("ENV_MODE") == "prod",
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(15),
        });
        Response.Cookies.Append(Cookies.RefreshToken, refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = Environment.GetEnvironmentVariable("ENV_MODE") == "prod",
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(30),
        });
    }

    private void DeleteTokenCookies()
    {
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.UtcNow.AddDays(-1),
        };
        Response.Cookies.Append(Cookies.AccessToken, string.Empty, cookieOptions);
        Response.Cookies.Append(Cookies.RefreshToken, string.Empty, cookieOptions);
    }
}