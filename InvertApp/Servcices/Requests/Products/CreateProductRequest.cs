using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Products
{
    public class CreateProductRequest : IRequest<Response<int>>
    {
        public Product RequestArgs { get; set; }

        public CreateProductRequest(Product requestArgs)
        {
            RequestArgs = requestArgs;

        }
    }
}