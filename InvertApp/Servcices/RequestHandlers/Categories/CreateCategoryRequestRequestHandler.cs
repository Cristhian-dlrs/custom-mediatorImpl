using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Categories;

namespace InvertApp.Servcices.RequestHandlers.Categories
{
    public class CreateCategoryRequestRequestHandler : IRequestHandler<CreateCategoryRequest, 
        Response<int>>
    {
        private readonly IGenericRepository<Category> _repository;

        public CreateCategoryRequestRequestHandler(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public Response<int> Handle(CreateCategoryRequest request)
        {
            var category = request.ReqeustArgs;
            var response = new Response<int>();
            
            try
            {
                _repository.Add(category);
                response.Message = $"A new Category was succesfuly created.";
                response.Success = true;
                response.Data = category.Id;
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
