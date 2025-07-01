using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Users.Register;
using Application.Commands.Users.Find;
using Application.Commands.Users.FindMany;
using Web.API.Constants;

namespace Web.API.Controllers;

[ApiController, Route(APIRoutes.Users)]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created($"{APIRoutes.Users}/{response.Id}", response);
    }

    [HttpGet, Route("{id}")]
    public async Task<ActionResult<FindUserResponse>> FindUser(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserRequest(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindManyUsersResponse>>> FindUsersBySkill(
        [FromQuery] FindManyUsersRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}