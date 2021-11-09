using System;
using System.Collections.Generic;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Categories;

namespace InvertApp.Servcices.RequestHandlers.Categories
{
    public class GetAllCategoriesRequestRequestHandler : IRequestHandler<GetAllCategoriesRequest, 
        Response<IEnumerable<Category>>>
    {
        private readonly IGenericRepository<Category> _repository;
        
        public GetAllCategoriesRequestRequestHandler(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
        
        public Response<IEnumerable<Category>> Handle(GetAllCategoriesRequest request)
        {
            var response = new Response<IEnumerable<Category>>();
            
            try
            {
                var categories = _repository.GetAll();
                response.Message = $"Succesful reqeust.";
                response.Success = true;
                response.Data = categories;
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