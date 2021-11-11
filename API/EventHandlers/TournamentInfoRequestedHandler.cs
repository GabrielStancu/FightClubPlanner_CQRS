using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class TournamentInfoRequestedHandler : IEntityEventHandler<int, TournamentInfoRequested>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentInfoRequestedHandler(
            ITournamentRepository tournamentRepository, 
            IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }
        public async Task<TournamentInfoRequested> HandleRequestAsync(int request)
        {
            var tournament = await _tournamentRepository.SelectTournamentWithDetailsByIdAsync(request);
            return _mapper.Map<Tournament, TournamentInfoRequested>(tournament);
        }
    }
}
