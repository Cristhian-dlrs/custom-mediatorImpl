using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Servcices.RequestHandlers.Products
{
    public class AddStockReqeustRequestHandler : IRequestHandler<AddStockRequest, Response<int>>
    {
        private readonly IGenericRepository<Product> _repository;

        public AddStockReqeustRequestHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public Response<int> Handle(AddStockRequest request)
        {
            var response = new Response<int>();

            try
            {
                var product = _repository.Get(x => x.Id == request.RequestArgs.Id);
                product.Strock += request.RequestArgs.Strock;
                _repository.Update(product);
                response.Message = $"The new product stock is {product.Strock}";
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