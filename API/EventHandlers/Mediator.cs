using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.EventHandlersInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.EventHandlers
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _services;

        public Mediator(IServiceProvider services)
        {
            _services = services;
        }

        public Task HandleRequest<T>(T request)
        {
            var handler = _services.GetService<IVoidEventHandler<T>>();
            return handler.HandleRequestAsync(request);
        }

        public Task<R> HandleRequest<T, R>(T request)
        {
            var handler = _services.GetService<IEntityEventHandler<T, R>>();
            return handler.HandleRequestAsync(request);
        }

        public Task<IReadOnlyList<R>> HandleCollectionRequest<T, R>(T request)
        {
            var handler = _services.GetService<ICollectionEventHandler<T, R>>();
            return handler.HandleRequestAsync(request);
        }

        public Task<IReadOnlyList<R>> HandleCollectionRequest<R>()
        {
            var handler = _services.GetService<IParameterlessCollectionEventHandler<R>>();
            return handler.HandleRequestAsync();
        }
    }
}
