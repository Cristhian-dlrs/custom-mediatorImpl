using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Categories
{
    public class CreateCategoryRequest : IRequest<Response<int>>
    {
        public Category ReqeustArgs { get; set; }

        public CreateCategoryRequest(Category reqeustArgs)
        {
            ReqeustArgs = reqeustArgs;
        }
    }
}