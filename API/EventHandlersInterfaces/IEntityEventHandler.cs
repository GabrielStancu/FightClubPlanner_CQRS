using System.Threading.Tasks;

namespace API.EventHandlersInterfaces
{
    public interface IEntityEventHandler<T, R>:IEventHandler
    {
        Task<R> HandleRequestAsync(T request);
    }
}
