using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Products
{
    public class UpdateProductRequest : IRequest<Response<int>>
    {
        public Product RequestArgs { get; set; }

        public UpdateProductRequest(Product requestArgs)
        {
            RequestArgs = requestArgs;
        }
    }
}