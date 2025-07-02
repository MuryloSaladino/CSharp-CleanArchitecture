using Application.Commands.UserSkills.Acquire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.API.Constants;

namespace Web.API.Controllers;

[ApiController, Route($"{APIRoutes.Users}/{APIRoutes.Skills}")]
public class UserSkillsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Acquire(
        AcquireSkillRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }
}