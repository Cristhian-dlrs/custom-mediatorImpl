using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Products
{
    public class ReduceStockReqeust : IRequest<Response<int>>
    {
        public Product RequestArgs { get; set; }

        public ReduceStockReqeust(Product requestArgs)

        {
            RequestArgs = requestArgs;
        }
    }
}