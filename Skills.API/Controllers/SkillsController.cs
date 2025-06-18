using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skills.API.Constants;

namespace Skills.API.Controllers;

[ApiController, Route(APIRoutes.Skills)]
public class SkillsController(IMediator mediator) : ControllerBase
{
    
}