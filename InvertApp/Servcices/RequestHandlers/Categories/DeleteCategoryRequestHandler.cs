using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Categories;

namespace InvertApp.Servcices.RequestHandlers.Categories
{
    public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, Response<int>>
    {
        private readonly IGenericRepository<Category> _repository;
        
        public DeleteCategoryRequestHandler(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public Response<int> Handle(DeleteCategoryRequest request)
        {
            var response = new Response<int>();
            
            try
            {
                _repository.Delete(request.RequestArgs);
                response.Message = $"Category with id {request.RequestArgs} was succesfily deleted.";
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