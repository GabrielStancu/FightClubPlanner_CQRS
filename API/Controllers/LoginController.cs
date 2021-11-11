using API.Commands;
using API.EventHandlers;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResultDTO>> Login(LoginRequested loginRequested)
        {
            var loginResult = await _mediator.HandleRequest<LoginRequested, LoginResultDTO>(loginRequested);
            return Ok(loginResult);
        }
    }
}
