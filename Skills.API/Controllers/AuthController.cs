using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skills.API.Constants;
using Skills.Application.Modules.Auth.Login;
using Skills.Application.Modules.Auth.Logout;

namespace Skills.API.Controllers;

[ApiController, Route(APIRoutes.Auth)]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost, Route("login")]
    public async Task<ActionResult> Login(
        LoginRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpDelete, Route("logout")]
    public async Task<ActionResult> Logout(
        [FromQuery] LogoutRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }
}