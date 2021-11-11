using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EventHandlersInterfaces
{
    public interface IParameterlessCollectionEventHandler<R>: IEventHandler
    {
        Task<IReadOnlyList<R>> HandleRequestAsync();
    }
}
