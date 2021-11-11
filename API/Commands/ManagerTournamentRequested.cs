using System;

namespace API.Commands
{
    public class ManagerTournamentRequested
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
    }
}
