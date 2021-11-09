using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Products
{
    public class DeleteProdcutRequest : IRequest<Response<int>>
    {
        public int RequestArgs { get; set; }

        public DeleteProdcutRequest(int requestArgs)
        {
            RequestArgs = requestArgs;
        }
    }
}