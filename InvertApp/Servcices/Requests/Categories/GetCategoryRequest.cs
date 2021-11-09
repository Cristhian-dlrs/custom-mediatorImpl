using System;
using System.Linq.Expressions;
using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Categories
{
    public class GetCategoryRequest : IRequest<Response<Category>>
    {
        public Expression<Func<Category, bool>> RequestArgs { get; set; }

        public GetCategoryRequest(Expression<Func<Category, bool>> requestArgs)
        {
            RequestArgs = requestArgs;
        }
    }
}