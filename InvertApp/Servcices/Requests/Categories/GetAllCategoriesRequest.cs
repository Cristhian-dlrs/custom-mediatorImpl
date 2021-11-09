using System.Collections.Generic;
using InvertApp.Data;
using InvertApp.Interfaces;

namespace InvertApp.Servcices.Requests.Categories
{
    public class GetAllCategoriesRequest : IRequest<Response<IEnumerable<Category>>>
    {
        
    }
}