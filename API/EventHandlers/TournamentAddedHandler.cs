using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class TournamentAddedHandler: IEntityEventHandler<TournamentAdded, bool>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentAddedHandler(
            ITournamentRepository tournamentRepository,
            IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }
        public async Task<bool> HandleRequestAsync(TournamentAdded request)
        {
            if (ValidCredentials(request))
            {
                bool takenName = await _tournamentRepository.TournamentNameTaken(request.Name);
                if (takenName)
                {
                    return false;
                }

                await _tournamentRepository.InsertAsync(_mapper.Map<TournamentAdded, Tournament>(request));
                return true;
            }

            return false;
        }

        private bool ValidCredentials(TournamentAdded request)
        {
            if (request.Name is null ||
                request.Location is null ||
                request.StartDate < DateTime.Today)
            {
                return false;
            }

            return true;
        }
    }
}
