using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Products
{
    public class AddStockRequest: IRequest<Response<int>>
    { 
        public Product RequestArgs { get; set; }

        public AddStockRequest(Product requestArgs)

        {
            RequestArgs = requestArgs;
        }
    }
}