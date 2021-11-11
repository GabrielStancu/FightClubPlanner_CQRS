using API.Commands;
using API.EventHandlersInterfaces;
using Core.Helpers;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class LoginRequestedHandler : IEntityEventHandler<LoginRequested, LoginResultDTO>
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IFighterRepository _fighterRepository;

        public LoginRequestedHandler(
            IManagerRepository managerRepository,
            IFighterRepository fighterRepository)
        {
            _managerRepository = managerRepository;
            _fighterRepository = fighterRepository;
        }
        public async Task<LoginResultDTO> HandleRequestAsync(LoginRequested request)
        {
            var managerId =
                await _managerRepository.SelectUserWithLoginInformationAsync(request.Username, request.Password);

            if (managerId > 0)
            {
                return new LoginResultDTO() { LoginSuccess = true, UserId = managerId, UserType = UserType.Manager };
            }

            var fighterId =
                    await _fighterRepository.SelectUserWithLoginInformationAsync(request.Username, request.Password);

            if (fighterId > 0)
            {
                return new LoginResultDTO() { LoginSuccess = true, UserId = fighterId, UserType = UserType.Fighter };
            }

            return new LoginResultDTO() { LoginSuccess = false, UserId = 0, UserType = UserType.NotRegistered };
        }
    }
}
