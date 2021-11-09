using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Servcices.RequestHandlers.Products
{
    public class GetProductRequestRequestHandler : IRequestHandler<GetProductRequest, Response<Product>>
    {
        private readonly IGenericRepository<Product> _repository;

        public GetProductRequestRequestHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public Response<Product> Handle(GetProductRequest request)
        {
            var response = new Response<Product>();
            
            try
            {
                var product = _repository.Get(request.RequestArgs, request.Include);
                response.Message = $"Succesful reqeust.";
                response.Success = true;
                response.Data = product;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                response.Data = null;
            }
            
            return response;
        }
    }
}