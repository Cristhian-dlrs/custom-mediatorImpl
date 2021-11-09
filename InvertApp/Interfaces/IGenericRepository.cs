using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InvertApp.Data;

namespace InvertApp.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string include = null);

        T Get(Expression<Func<T, bool>> expression, string include = null);

        void Add(T entity);
        
        void Update(T entity);

        void Delete(int id);
    }
}