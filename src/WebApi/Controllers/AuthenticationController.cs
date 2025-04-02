using CleanArch.Application.Commands.User.Command;
using Microsoft.AspNetCore.Http.Extensions;
using CleanArch.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CleanArch.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public IActionResult Register(UserCreateCommand command)
    {
        var response = _mediator.Send(command);
        return Created(HttpContext.Request.GetDisplayUrl(), response.Result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginCommand command)
    {
        try
        {
            var response = _mediator.Send(command);
            return await Task.FromResult(Created(HttpContext.Request.GetDisplayUrl(), response.Result));
        }
        catch (UserException ex)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Login Error",
                Detail = ex.Message,
                Status = StatusCodes.Status401Unauthorized,
                Instance = HttpContext.Request.Path
            };

            return BadRequest(problemDetails);
        }
    }
}
