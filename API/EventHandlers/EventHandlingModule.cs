using API.Commands;
using API.EventHandlersInterfaces;
using Core.Helpers;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.TournamentStrategies;
using Microsoft.Extensions.DependencyInjection;

namespace API.EventHandlers
{
    public static class EventHandlingModule
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IVoidEventHandler<InviteAnswered>, InviteAnsweredHandler>();
            services.AddScoped<ICollectionEventHandler<TestRegistered, TestRegistered>, TestRegisteredHandler>();
            services.AddScoped<IEntityEventHandler<int, DetailedFighter>, DetailedFighterHandler>();
            services.AddScoped<IParameterlessCollectionEventHandler<IsolationBubble>, IsolationBubblesRequestedHandler>();
            services.AddScoped<IEntityEventHandler<TournamentAdded, bool>, TournamentAddedHandler>();
            services.AddScoped<ICollectionEventHandler<int, ManagerTournamentRequested>, ManagerTournamentsRequestedHandler>();
            services.AddScoped<IEntityEventHandler<int, TournamentInfoRequested>, TournamentInfoRequestedHandler>();
            services.AddScoped<ICollectionEventHandler<int, InvitableFighterRequested>, InvitableFightersRequestedHandler>();
            services.AddScoped<IEntityEventHandler<InviteSent, bool>, InviteSentHandler>();
            services.AddScoped<IEntityEventHandler<(int, IMatchStrategy), bool>, FightsGeneratedHandler>();
            services.AddScoped<IEntityEventHandler<WonFight, bool>, WonFightHandler>();
            services.AddScoped<IEntityEventHandler<int, bool>, RescheduledFightHandler>();
            services.AddScoped<IEntityEventHandler<LoginRequested, LoginResultDTO>, LoginRequestedHandler>();
            services.AddScoped<IEntityEventHandler<SignupRequested, SignupResult>, SignupRequestedHandler>();
        }
    }
}
