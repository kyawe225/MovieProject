using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application;

namespace MovieProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _messageBus;
        public HomeController(ILogger<HomeController> logger, IMediator handler)
        {
            _logger = logger;
            _messageBus = handler;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerChallengeType.AccessToken)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Index()
        {
            _logger.LogInformation("Hello World");
            return Ok("Movie Project API is running...");
        }

        // [HttpPost("add")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> Add([FromBody]ActorDto dto, CancellationToken token)
        // {
        //     // var response= await _messageBus.Send<IActionResult>(new ActorCreateCommand(new Query.Actor.ActorCreateQuery(dto)));
        //     // _logger.LogInformation("Hello World");
        //     // return response;
        // }
        
        // [HttpGet("actor/list")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> Add(CancellationToken token)
        // {
        //     // var response= await _messageBus.Send<IActionResult>(new ActorListCommand());
        //     // _logger.LogInformation("Hello World");
        //     // return response;
        // }
    }
}
