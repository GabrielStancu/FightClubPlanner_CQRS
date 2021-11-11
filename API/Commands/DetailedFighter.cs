using Infrastructure.DTOs;
using System.Collections.Generic;

namespace API.Commands
{
    public class DetailedFighter
    {
        public List<FightDTO> FightHistory { get; set; }
        public List<CovidTestDTO> TestHistory { get; set; }
        public List<TournamentDTO> Tournaments { get; set; }
        public List<InviteDTO> Invites { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public bool IsEligible { get; set; }
    }
}
