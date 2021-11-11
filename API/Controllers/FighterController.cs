using API.Commands;
using API.EventHandlers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FighterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FighterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<ActionResult> AnswerInvite(InviteAnswered request)
        {
            await _mediator.HandleRequest(request);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<IReadOnlyList<TestRegistered>>> RegisterTest(TestRegistered request)
        {
            var tests = await _mediator.HandleCollectionRequest<TestRegistered, TestRegistered>(request);
            return Ok(tests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailedFighter>> GetFighterDetails(int id)
        {
            var fighter = await _mediator.HandleRequest<int, DetailedFighter>(id);
            return Ok(fighter);
        }

        [HttpGet("isolationBubbles")]
        public async Task<ActionResult<IReadOnlyList<IsolationBubble>>> GetIsolationBubbles()
        {
            var isolationBubbles = await _mediator.HandleCollectionRequest<IsolationBubble>();
            return Ok(isolationBubbles);
        }
    }
}
