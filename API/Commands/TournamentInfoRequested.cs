using Infrastructure.DTOs;
using System;
using System.Collections.Generic;

namespace API.Commands
{
    public class TournamentInfoRequested
    {
        public int Id { get; set; }
        public List<FighterDTO> Fighters { get; set; }
        public List<FightDTO> Fights { get; set; }
        public DateTime StartDate { get; set; }
    }
}
