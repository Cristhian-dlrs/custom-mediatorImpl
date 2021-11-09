using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Categories
{
    public class DeleteCategoryRequest : IRequest<Response<int>>
    {
        public int RequestArgs { get; set; }

        public DeleteCategoryRequest(int requestArgs)
        {
            RequestArgs = requestArgs;
        }
    }
}