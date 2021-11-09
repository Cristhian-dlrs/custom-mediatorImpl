using System;
using System.Collections.Generic;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Servcices.RequestHandlers.Products
{
    public class GetAllProductsRequestRequestHandler : IRequestHandler<GetAllProductsRequest, Response<IEnumerable<Product>>>
    {
        private readonly IGenericRepository<Product> _repository;

        public GetAllProductsRequestRequestHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public Response<IEnumerable<Product>> Handle(GetAllProductsRequest request)
        {
            var response = new Response<IEnumerable<Product>>();
            
            try
            {
                var products = _repository.GetAll(request.Include);
                response.Message = $"Succesful reqeust.";
                response.Success = true;
                response.Data = products;
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