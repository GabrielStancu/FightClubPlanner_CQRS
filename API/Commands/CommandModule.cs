using AutoMapper;
using Core.Models;

namespace API.Commands
{
    public class CommandModule : Profile
    {
        public CommandModule()
        {
            CreateMap<Fighter, DetailedFighter>();
            CreateMap<LoginRequested, User>();
            CreateMap<SignupRequested, Manager>();
            CreateMap<SignupRequested, Fighter>();
            CreateMap<TournamentAdded, Tournament>();
            CreateMap<Tournament, ManagerTournamentRequested>();
            CreateMap<Tournament, TournamentInfoRequested>();
            CreateMap<InviteSent, Invite>();
            CreateMap<InviteAnswered, Invite>();
            CreateMap<Invite, InviteAnswered>();
            CreateMap<CovidTest, TestRegistered>();
            CreateMap<Fighter, InvitableFighterRequested>();
            CreateMap<WonFight, Fight>();
        }
    }
}
