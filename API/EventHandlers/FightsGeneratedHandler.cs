using API.EventHandlersInterfaces;
using Infrastructure.Repositories;
using Infrastructure.TournamentStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class FightsGeneratedHandler : IEntityEventHandler<(int TournamentId, IMatchStrategy Strategy), bool>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITournamentScheduler _tournamentScheduler;

        public FightsGeneratedHandler(
            ITournamentRepository tournamentRepository,
            ITournamentScheduler tournamentScheduler)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentScheduler = tournamentScheduler;
        }

        public async Task<bool> HandleRequestAsync((int TournamentId, IMatchStrategy Strategy) request)
        {
            var tournament = await _tournamentRepository.SelectTournamentWithDetailsByIdAsync(request.TournamentId);

            for (int i = 0; i < 2; i++)
            {
                if (await _tournamentScheduler.AddFight(request.Strategy, tournament) == false)
                {
                    return false;
                }
            }

            await _tournamentScheduler.Build(tournament);

            return true;
        }
    }
}
