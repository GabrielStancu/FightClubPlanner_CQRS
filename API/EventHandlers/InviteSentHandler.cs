using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class InviteSentHandler : IEntityEventHandler<InviteSent, bool>
    {
        private readonly IInviteRepository _inviteRepository;
        private readonly IMapper _mapper;

        public InviteSentHandler(
            IInviteRepository inviteRepository,
            IMapper mapper)
        {
            _inviteRepository = inviteRepository;
            _mapper = mapper;
        }
        public async Task<bool> HandleRequestAsync(InviteSent request)
        {
            await _inviteRepository.InsertAsync(_mapper.Map<InviteSent, Invite>(request));
            return true;
        }
    }
}
