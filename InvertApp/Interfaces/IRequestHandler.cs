
using System;

namespace InvertApp.Interfaces
{
    public interface IRequestHandler<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest request);
    }
}