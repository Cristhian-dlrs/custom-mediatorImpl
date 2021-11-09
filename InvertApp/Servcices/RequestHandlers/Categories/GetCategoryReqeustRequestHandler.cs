using System;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Categories;

namespace InvertApp.Servcices.RequestHandlers.Categories
{
    public class GetCategoryReqeustRequestHandler : IRequestHandler<GetCategoryRequest, Response<Category>>
    {
        private readonly IGenericRepository<Category> _repository;
        
        public GetCategoryReqeustRequestHandler(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
        
        public Response<Category> Handle(GetCategoryRequest request)
        {
            var response = new Response<Category>();
            
            try
            {
               var category =  _repository.Get(request.RequestArgs);
                response.Message = $"Succesful reqeust.";
                response.Success = true;
                response.Data = category;
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