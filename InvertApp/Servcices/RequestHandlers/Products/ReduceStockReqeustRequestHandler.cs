using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Servcices.RequestHandlers.Products
{
    public class ReduceStockReqeustRequestHandler : IRequestHandler<ReduceStockReqeust, Response<int>>
    {
        private readonly IGenericRepository<Product> _repository;

        public ReduceStockReqeustRequestHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public Response<int> Handle(ReduceStockReqeust request)
        {
            var response = new Response<int>();

            try
            {
                var product = _repository.Get(x => x.Id == request.RequestArgs.Id);
                product.Strock -= request.RequestArgs.Strock;

                if (product.Strock < 0)
                    throw new Exception("Insufficient stock.");
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