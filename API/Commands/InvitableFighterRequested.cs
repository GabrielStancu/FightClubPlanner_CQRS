using Core.Helpers;

namespace API.Commands
{
    public class InvitableFighterRequested
    {
        public UserType UserType { get; set; } = UserType.Fighter;
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public bool IsEligible { get; set; }
    }
}
