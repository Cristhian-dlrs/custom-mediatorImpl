using System;
using System.Linq.Expressions;
using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Products
{
    public class GetProductRequest : IRequest<Response<Product>>
    {
        public Expression<Func<Product, bool>> RequestArgs { get; set; }

        public string Include { get; set; } = "Category";

        public GetProductRequest(Expression<Func<Product, bool>> requestArgs)
        {
            RequestArgs = requestArgs;
        } 
    }
}