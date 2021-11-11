using Infrastructure.Repositories;
using Infrastructure.TournamentStrategies;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped(typeof(IUserRepository<>), (typeof(UserRepository<>)));
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IFighterRepository, FighterRepository>();
            services.AddScoped<ITournamentFighterRepository, TournamentFighterRepository>();
            services.AddScoped<ICovidTestRepository, CovidTestRepository>();
            services.AddScoped<IFightRepository, FightRepository>();
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddScoped<IIsolationBubbleRepository, IsolationBubbleRepository>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();
        }

        public static void RegisterStrategy(this IServiceCollection services)
        {
            services.AddScoped<IMatchGenerator, MatchGenerator>();
            services.AddScoped<ITournamentScheduler, TournamentScheduler>();
        }
    }
}
