using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Skills.Application.Features.Users.Login;
using Skills.Application.Features.Users.Register;

namespace Skills.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;


    [HttpPost]
    public async Task<ActionResult<RegisterUserReponse>> RegisterUser(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created("/api/users", response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> LoginUser(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}