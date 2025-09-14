using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application;
using MovieProject.Application.Features.Genres;
using MovieProject.Application.Models;

namespace MovieProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerChallengeType.AccessToken)]
    public class GenreController(IMediator _messageBus, ILogger<GenreController> _logger) : ControllerBase
    {
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateGenreCommand dto)
        {
            var response = await _messageBus.Send<ResponseModel<string>>(dto, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List()
        {
            var response = await _messageBus.Send<ResponseModel<List<ListGenreResponse>>>(new ListGenreQuery(), HttpContext.RequestAborted);
            return Ok(response);
        }
        
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string Id, [FromBody] UpdateGenreCommand command)
        {
            command.Id = Id;
            var response= await _messageBus.Send<ResponseModel<Unit?>>(command,HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Detail(string Id)
        {
            var response= await _messageBus.Send<ResponseModel<ListGenreResponse>>(new DetailGenreCommand(Id),HttpContext.RequestAborted);
            return Ok(response);
        }
        
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string Id)
        {
            var response= await _messageBus.Send<ResponseModel<Unit?>>(new DeleteGenreCommand(Id), HttpContext.RequestAborted);
            return Ok(response);
        }
    }
}
