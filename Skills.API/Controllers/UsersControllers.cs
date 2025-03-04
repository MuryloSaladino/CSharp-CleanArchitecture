using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skills.API.Middlewares.Authenticate;
using Skills.Application.Features.Users.Register;
using Skills.Application.Features.Users.Find;

namespace Skills.API.Controllers;

[ApiController]
[Route("/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created("/users", response);
    }

    [HttpGet]
    [Route("{id}")]
    [Authenticate]
    public async Task<ActionResult<FindUserResponse>> FindUser(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserRequest(id), cancellationToken);
        return Ok(response);
    }
}