using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skills.API.Middlewares.Authenticate;
using Skills.Application.Features.Skills.Create;
using Skills.Application.Features.Skills.Delete;
using Skills.Application.Features.Skills.Edit;

namespace Skills.API.Controllers;

[ApiController]
[Route("/skills")]
[Authenticate]
public class SkillsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateSkillResponse>> CreateSkill(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created("/skills", response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<EditSkillResponse>> EditSkill(
        [FromRoute] string id, EditSkillRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteSkill(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteSkillRequest(id), cancellationToken);
        return NoContent();
    }
}