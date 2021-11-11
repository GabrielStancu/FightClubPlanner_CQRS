using API.EventHandlersInterfaces;
using Core.Models;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class IsolationBubblesRequestedHandler : IParameterlessCollectionEventHandler<IsolationBubble>
    {
        private readonly IIsolationBubbleRepository _isolationBubbleRepository;

        public IsolationBubblesRequestedHandler(IIsolationBubbleRepository isolationBubbleRepository)
        {
            _isolationBubbleRepository = isolationBubbleRepository;
        }
        public async Task<IReadOnlyList<IsolationBubble>> HandleRequestAsync()
        {
            var isolationBubbles = await _isolationBubbleRepository.SelectAllIsolationBubblesAsync();
            return isolationBubbles;
        }
    }
}
