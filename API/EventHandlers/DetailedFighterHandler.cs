using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class DetailedFighterHandler : IEntityEventHandler<int, DetailedFighter>
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;

        public DetailedFighterHandler(
            IFighterRepository fighterRepository,
            IMapper mapper)
        {
            _fighterRepository = fighterRepository;
            _mapper = mapper;
        }
        public async Task<DetailedFighter> HandleRequestAsync(int request)
        {
            var fighter = await _fighterRepository.SelectFighterWithDataAsync(request);
            return _mapper.Map<Fighter, DetailedFighter>(fighter);
        }
    }
}
