using System;

namespace API.Commands
{
    public class TournamentAdded
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int OrganizerId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
