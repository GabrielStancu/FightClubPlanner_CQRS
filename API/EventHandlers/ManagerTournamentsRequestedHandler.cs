using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class ManagerTournamentsRequestedHandler : ICollectionEventHandler<int, ManagerTournamentRequested>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public ManagerTournamentsRequestedHandler(
            ITournamentRepository tournamentRepository,
            IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ManagerTournamentRequested>> HandleRequestAsync(int request)
        {
            var tournaments = await _tournamentRepository.SelectTournamentsByManagerIdAsync(request);
            var mappedTournaments = new List<ManagerTournamentRequested>();
            tournaments.ForEach(t => mappedTournaments.Add(_mapper.Map<Tournament, ManagerTournamentRequested>(t)));
            return mappedTournaments;
        }
    }
}
