﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Commands
{
    public class WonFight
    {
        public int Id { get; set; }
        public int FighterId1 { get; set; }
        public string FighterName1 { get; set; }
        public int FighterId2 { get; set; }
        public string FighterName2 { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime FightTime { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
    }
}
