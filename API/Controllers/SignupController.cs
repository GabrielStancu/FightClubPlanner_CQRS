using API.Commands;
using API.EventHandlers;
using Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SignupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<SignupResult>> SignUp(SignupRequested signupRequested)
        {
            var signupResult = await _mediator.HandleRequest<SignupRequested, SignupResult>(signupRequested);
            return Ok(signupResult);
        }
    }
}
