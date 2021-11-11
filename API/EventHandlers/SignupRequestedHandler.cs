using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Helpers;
using Core.Models;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class SignupRequestedHandler: IEntityEventHandler<SignupRequested, SignupResult>
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;

        public SignupRequestedHandler(
            IManagerRepository managerRepository,
            IFighterRepository fighterRepository,
            IMapper mapper)
        {
            _managerRepository = managerRepository;
            _fighterRepository = fighterRepository;
            _mapper = mapper;
        }
        public async Task<SignupResult> HandleRequestAsync(SignupRequested request)
        {
            bool existsManager =
            await _managerRepository.CheckAlreadyRegisteredUserAsync(request.Username);

            bool existsFighter =
                await _fighterRepository.CheckAlreadyRegisteredUserAsync(request.Username);

            if (!existsManager && !existsFighter)
            {
                if (request.UserType == UserType.Manager)
                {
                    return await CheckManager(request);
                }
                else
                {
                    return await CheckFighter(request);
                }
            }
            else
            {
                return SignupResult.UserAlreadyRegistered;
            }
        }

        private async Task<SignupResult> CheckManager(SignupRequested signupRequest)
        {
            if (!AllManagerFieldsValid(signupRequest))
            {
                return SignupResult.BadCredentials;
            }

            await _managerRepository.RegisterUserAsync(_mapper.Map<SignupRequested, Manager>(signupRequest));
            return SignupResult.Registered;
        }

        private async Task<SignupResult> CheckFighter(SignupRequested signupRequest)
        {
            if (!AllFighterFieldsValid(signupRequest))
            {
                return SignupResult.BadCredentials;
            }

            await _fighterRepository.RegisterUserAsync(_mapper.Map<SignupRequested, Fighter>(signupRequest));
            return SignupResult.Registered;
        }

        private bool AllManagerFieldsValid(SignupRequested signupRequest)
        {
            return !(signupRequest.Username is null ||
                    signupRequest.Password is null ||
                    signupRequest.RepeatedPassword is null ||
                    signupRequest.FirstName is null ||
                    signupRequest.LastName is null ||
                    !signupRequest.Password.Equals(signupRequest.RepeatedPassword));
        }

        private bool AllFighterFieldsValid(SignupRequested signupRequest)
        {
            return !(signupRequest.Username is null ||
                    signupRequest.Password is null ||
                    signupRequest.RepeatedPassword is null ||
                    signupRequest.FirstName is null ||
                    signupRequest.LastName is null ||
                    !signupRequest.Password.Equals(signupRequest.RepeatedPassword) ||
                    signupRequest.Weight < 40 ||
                    signupRequest.Weight > 150 ||
                    signupRequest.Height < 120 ||
                    signupRequest.Height > 250 ||
                    (DateTime.Today - signupRequest.Birthday).Days / 365 < 18
                    );
        }
    }
}
