using System.Collections.Generic;
using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Products
{
    public class GetAllProductsRequest : IRequest<Response<IEnumerable<Product>>>
    {
        public string Include { get; set; } = "Category";
    }
}