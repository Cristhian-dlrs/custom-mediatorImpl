using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using InvertApp.Interfaces;

namespace InvertApp.Servcices
{
    public class Mediator : IMediator
    {
        private readonly IDictionary<Type, Type> _handlers;
        private readonly Func<Type, object> _serviceLocator;

        public Mediator(Func<Type, object> serviceLocator, IDictionary<Type, Type> handlers)
        {
            _serviceLocator = serviceLocator;
            _handlers = handlers;
        }

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            if (request == null)
                throw new Exception("Invalid request.");
            
            var requestType = request.GetType();
            if (!_handlers.ContainsKey(requestType))
                throw new Exception("Handler not found.");

            _handlers.TryGetValue(requestType, out var handlerType);
            var handler = _serviceLocator(handlerType);

           return (TResponse)handler.GetType().GetMethod("Handle").Invoke(handler, new[] { request });
        }
    }
}



