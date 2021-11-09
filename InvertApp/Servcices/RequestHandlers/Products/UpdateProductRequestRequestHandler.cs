using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Servcices.RequestHandlers.Products
{
    public class UpdateProductRequestRequestHandler : IRequestHandler<UpdateProductRequest, Response<int>>
    {
        private readonly IGenericRepository<Product> _repository;

        public UpdateProductRequestRequestHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public Response<int> Handle(UpdateProductRequest request)
        {
            var response = new Response<int>();
            
            try
            {
                _repository.Update(request.RequestArgs);
                response.Message = $"Product with id {request.RequestArgs} was succesfily updated.";
                response.Success = true;
                response.Data = request.RequestArgs.Id;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                response.Data = request.RequestArgs.Id;
            }
            
            return response;
        }
    }
}