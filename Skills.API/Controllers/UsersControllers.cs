using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skills.API.Middlewares.Authenticate;
using Skills.Application.Features.Users.Register;
using Skills.Application.Features.Users.Find;
using Skills.Application.Features.Users.FindBySkill;
using Skills.API.Middlewares.Authorize;
using Skills.Application.Features.Users.Promote;

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

    [HttpGet, Route("{id}")]
    [Authenticate]
    public async Task<ActionResult<FindUserResponse>> FindUser(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserRequest(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    [Authenticate, Authorize]
    public async Task<ActionResult<List<FindUsersBySkillResponse>>> FindUsersBySkill(
        [FromQuery] string? skillname, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUsersBySkillRequest(skillname ?? ""), cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("promote/{id}")]
    [Authenticate, Authorize]
    public async Task<ActionResult<PromoteUserResponse>> PromoteUser(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new PromoteUserRequest(id), cancellationToken);
        return Ok(response);
    }
}