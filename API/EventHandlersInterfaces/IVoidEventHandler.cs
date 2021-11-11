using System.Threading.Tasks;

namespace API.EventHandlersInterfaces
{
    public interface IVoidEventHandler<T>:IEventHandler
    {
        Task HandleRequestAsync(T request);
    }
}