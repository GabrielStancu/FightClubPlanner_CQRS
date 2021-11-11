using AutoMapper;
using Core.Models;

namespace Infrastructure.DTOs
{
    public class DtoModule : Profile
    {
        public DtoModule()
        {
            CreateMap<Manager, ManagerDTO>();
            CreateMap<FightDTO, Fight>();
            CreateMap<Tournament, TournamentDTO>();
            CreateMap<Fighter, FighterDTO>()
                .ForMember(dest => dest.TestsCount,
                map => map.MapFrom(
                    src => src.TestHistory.Count
                    ));

            CreateMap<CovidTest, CovidTestDTO>()
                .ForMember(dest => dest.IsolationBubbleName,
                map => map.MapFrom(
                    src => src.IsolationBubble.Name
                    ));

            CreateMap<Invite, InviteDTO>()
                .ForMember(dest => dest.TournamentName,
                map => map.MapFrom(
                    src => src.Tournament.Name
                    ));

            CreateMap<Fight, FightDTO>()
                .ForMember(dest => dest.FighterName1,
                map => map.MapFrom(
                    src => src.Fighter1.FullName
                    ))
                .ForMember(dest => dest.FighterName2,
                map => map.MapFrom(
                    src => src.Fighter2.FullName
                    ))
                .ForMember(dest => dest.WinnerName,
                map => map.MapFrom(
                    src => src.Winner.FullName
                    ))
                .ForMember(dest => dest.TournamentName,
                map => map.MapFrom(
                    src => src.Tournament.Name
                    ));           
        }
    }
}
