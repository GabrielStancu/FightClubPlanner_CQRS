using Core.Models;
using System;

namespace API.Commands
{
    public class InviteSent
    {
        public int Id { get; set; }
        public int FighterId { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string TournamentLocation { get; set; }
        public DateTime DateSent { get; set; }
        public InviteState InviteState { get; set; }
    }
}
