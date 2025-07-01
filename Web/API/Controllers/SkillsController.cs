using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.API.Constants;
using Application.Commands.Skills.Create;
using Application.Commands.Skills.Delete;

namespace Web.API.Controllers;

[ApiController, Route(APIRoutes.Skills)]
public class SkillsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateSkillResponse>> Create(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Skills, response);
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteSkillRequest(id), cancellationToken);
        return NoContent();
    }
}