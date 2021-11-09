using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Servcices.RequestHandlers.Products
{
    public class CreateProductReqeustRequestHandler : IRequestHandler<CreateProductRequest, Response<int>>
    {
        private readonly IGenericRepository<Product> _repository;

        public CreateProductReqeustRequestHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }
        
        public Response<int> Handle(CreateProductRequest request)
        {
            var product = request.RequestArgs;
            var response = new Response<int>();
            
            try
            {
                _repository.Add(product);
                response.Message = $"A new Product was succesfuly added.";
                response.Success = true;
                response.Data = product.Id;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                response.Data = 0;
            }
            
            return response;
        }
    }
}