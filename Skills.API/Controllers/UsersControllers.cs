using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skills.Application.Usecases.Users.Register;
using Skills.Application.Usecases.Users.Find;
using Skills.Application.Usecases.Users.FindBySkill;
using Skills.API.Constants;

namespace Skills.API.Controllers;

[ApiController, Route(APIRoutes.Users)]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    [HttpGet, Route("{id}")]
    public async Task<ActionResult<FindUserResponse>> FindUser(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserRequest(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindUsersBySkillResponse>>> FindUsersBySkill(
        [FromQuery] FindUsersBySkillRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}