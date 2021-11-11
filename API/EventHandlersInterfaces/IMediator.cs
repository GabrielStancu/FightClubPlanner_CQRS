using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public interface IMediator
    {
        Task<IReadOnlyList<R>> HandleCollectionRequest<T, R>(T request);
        Task<IReadOnlyList<R>> HandleCollectionRequest<R>();
        Task<R> HandleRequest<T, R>(T request);
        Task HandleRequest<T>(T request);
    }
}