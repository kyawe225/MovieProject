using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Features.Auth;
using MovieProject.Application.Features.Director;
using MovieProject.Application.Models;

namespace MovieProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator _messageBus, ILogger<AuthController> _logger) : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] AuthLoginCommand dto)
        {
            var response = await _messageBus.Send<ResponseModel<AuthLoginResponse>>(dto, HttpContext.RequestAborted);
            return Ok(response);
        }
    }
}
