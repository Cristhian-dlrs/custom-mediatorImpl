using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Categories;

namespace InvertApp.Servcices.RequestHandlers.Categories
{
    public class UpdateCategoryRequestRequestHandler : IRequestHandler<UpdateCategoryRequest, Response<int>>
    {
        private readonly IGenericRepository<Category> _repository;
        
        public UpdateCategoryRequestRequestHandler(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public Response<int> Handle(UpdateCategoryRequest request)
        {
            var response = new Response<int>();
            
            try
            {
                _repository.Update(request.RequestArgs);
                response.Message = $"Category with id {request.RequestArgs} was succesfily updated.";
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