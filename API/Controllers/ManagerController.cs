using API.Commands;
using API.EventHandlers;
using Infrastructure.TournamentStrategies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("tournaments")]
        public async Task<ActionResult<bool>> AddTournament(TournamentAdded tournamentAdded)
        {
            bool added = await _mediator.HandleRequest<TournamentAdded, bool>(tournamentAdded); 
            return Ok(added);
        }

        [HttpGet("tournaments/{id}")]
        public async Task<ActionResult<IReadOnlyList<ManagerTournamentRequested>>> GetTournamentsForManager(int id)
        {
            var tournaments = await _mediator.HandleCollectionRequest<int, ManagerTournamentRequested>(id);
            return Ok(tournaments);
        }

        [HttpGet("tournamentdetails/{id}")]
        public async Task<ActionResult<TournamentInfoRequested>> GetTournamentInfo(int id)
        {
            var tournament = await _mediator.HandleRequest<int, TournamentInfoRequested>(id);
            return Ok(tournament);
        }

        [HttpGet("invitableFighters/{id}")]
        public async Task<ActionResult<IReadOnlyList<InvitableFighterRequested>>> GetInvitableFighters(int id)
        {
            var invitableFighters = await _mediator.HandleCollectionRequest<int, InvitableFighterRequested>(id);
            return Ok(invitableFighters);
        }

        [HttpPost("invites")]
        public async Task<ActionResult<bool>> SendInvite(InviteSent invite)
        {
            var sentInvite = await _mediator.HandleRequest<InviteSent, bool>(invite);
            return Ok(sentInvite);
        }

        [HttpGet("weeklyfights/{tournamentId}")]
        public async Task<ActionResult<bool>> GenerateWeeklyFights(int tournamentId)
        {
            var generatedFights = await _mediator.HandleRequest<(int, IMatchStrategy), bool>((tournamentId, new WeeklyMatchStrategy()));
            return Ok(generatedFights);
        }

        [HttpGet("monthlyfights/{tournamentId}")]
        public async Task<ActionResult<bool>> GenerateMonthlyFights(int tournamentId)
        {
            var generatedFights = await _mediator.HandleRequest<(int, IMatchStrategy), bool>((tournamentId, new MonthlyMatchStrategy()));
            return Ok(generatedFights);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> SetFightWinner(WonFight wonFight)
        {
            var setWinner = await _mediator.HandleRequest<WonFight, bool>(wonFight);
            return Ok(true);
        }

        [HttpGet("reschedule/{tournamentId}")]
        public async Task<ActionResult<bool>> RescheduleFights(int tournamentId)
        {
            var rescheduled = await _mediator.HandleRequest<int, bool>(tournamentId);
            return Ok(rescheduled);
        }
    }
}
