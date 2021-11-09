using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Categories
{
    public class UpdateCategoryRequest : IRequest<Response<int>>
    {
        public Category RequestArgs { get; set; }

        public UpdateCategoryRequest(Category requestArgs)
        {
            RequestArgs = requestArgs;
        }
    }
}