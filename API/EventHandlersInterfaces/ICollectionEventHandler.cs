using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EventHandlersInterfaces
{
    public interface ICollectionEventHandler<T, R>:IEventHandler
    {
        Task<IReadOnlyList<R>> HandleRequestAsync(T request);
    }
}
