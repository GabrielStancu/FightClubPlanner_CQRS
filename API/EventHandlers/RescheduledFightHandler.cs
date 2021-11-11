using API.EventHandlersInterfaces;
using Core.Models;
using Infrastructure.Repositories;
using Infrastructure.TournamentStrategies;
using System;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class RescheduledFightHandler : IEntityEventHandler<int, bool>
    {
        private readonly IFightRepository _fightRepository;
        private readonly IMatchGenerator _matchGenerator;

        public RescheduledFightHandler(
            IFightRepository fightRepository,
            IMatchGenerator matchGenerator)
        {
            _fightRepository = fightRepository;
            _matchGenerator = matchGenerator;
        }
        public async Task<bool> HandleRequestAsync(int request)
        {
            var fights = await _fightRepository.SelectAllFightsByTournamentIdAsync(request);
            foreach (var fight in fights)
            {
                if (fight.FightTime == DateTime.Today)
                {
                    if (!fight.Fighter1.CanFight(DateTime.Today) || !fight.Fighter2.CanFight(DateTime.Today))
                    {
                        (Fighter fighter1, Fighter fighter2) = await _matchGenerator.GetBestMatch(request, fights);

                        if (fighter1.Id == 0 || fighter2.Id == 0)
                        {
                            return false;
                        }

                        fight.FighterId1 = fighter1.Id;
                        fight.FighterId2 = fighter2.Id;
                        await _fightRepository.UpdateAsync(fight);
                    }
                }
            }

            return true;
        }
    }
}
