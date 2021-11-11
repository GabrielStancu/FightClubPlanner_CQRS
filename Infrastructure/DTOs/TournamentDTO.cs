using System;
using System.Collections.Generic;

namespace Infrastructure.DTOs
{
    public class TournamentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<FighterDTO> Fighters { get; set; }
        public List<FightDTO> Fights { get; set; }
        public DateTime StartDate { get; set; }
    }
}
