using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Servcices.RequestHandlers.Products
{
    public class DeleteProductRequestRequestHandler : IRequestHandler<DeleteProdcutRequest, Response<int>>
    {
        private readonly IGenericRepository<Product> _repository;

        public DeleteProductRequestRequestHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }
        
        public Response<int> Handle(DeleteProdcutRequest request)
        {
            var response = new Response<int>();
            
            try
            {
                _repository.Delete(request.RequestArgs);
                response.Message = $"Product with id {request.RequestArgs} was succesfily deleted.";
                response.Success = true;
                response.Data = request.RequestArgs;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                response.Data = request.RequestArgs;
            }
            
            return response;
        }
    }
}