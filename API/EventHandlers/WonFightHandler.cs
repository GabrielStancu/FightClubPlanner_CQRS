using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class WonFightHandler : IEntityEventHandler<WonFight, bool>
    {
        private readonly IFightRepository _fightRepository;
        private readonly IMapper _mapper;

        public WonFightHandler(
            IFightRepository fightRepository,
            IMapper mapper)
        {
            _fightRepository = fightRepository;
            _mapper = mapper;
        }
        public async Task<bool> HandleRequestAsync(WonFight request)
        {
            await _fightRepository.UpdateAsync(_mapper.Map<WonFight, Fight>(request));
            return true;
        }
    }
}
