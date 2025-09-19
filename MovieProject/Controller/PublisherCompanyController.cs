using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application;
using MovieProject.Application.Features.PublisherCompanies;
using MovieProject.Application.Models;

namespace MovieProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerChallengeType.AccessToken)]
    public class PublisherCompanyController(IMediator _messageBus, ILogger<PublisherCompanyController> _logger) : ControllerBase
    {
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreatePublisherCompanyCommand dto)
        {
            var response = await _messageBus.Send<ResponseModel<string>>(dto, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List()
        {
            var response = await _messageBus.Send<ResponseModel<List<ListPublisherCompanyResponse>>>(new ListPublisherCompanyQuery(), HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string Id, [FromBody] UpdatePublisherCompanyCommand command)
        {
            command.Id = Id;
            var response = await _messageBus.Send<ResponseModel<Unit?>>(command, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Detail(string Id)
        {
            var response = await _messageBus.Send<ResponseModel<ListPublisherCompanyResponse>>(new DetailPublisherCompanyCommand(Id), HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string Id)
        {
            var response = await _messageBus.Send<ResponseModel<Unit?>>(new DeletePublisherCompanyCommand(Id), HttpContext.RequestAborted);
            return Ok(response);
        }
    }
}
