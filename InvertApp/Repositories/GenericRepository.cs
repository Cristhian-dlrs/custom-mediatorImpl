using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InvertApp.Data;
using InvertApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvertApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly InvertAppContext _dbContext;
        private readonly DbSet<T> _db;

        public GenericRepository(InvertAppContext dbContext)
        {
            _dbContext = dbContext;
            _db = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll(string include = null)
        {
            var task = Task.Run(() =>
            {
                IQueryable<T> query = _db;
                if (include != null)
                    query.Include(include);
                return query.AsNoTracking().ToList();
            });
            task.Wait();
            return task.Result;
        }

        public T Get(Expression<Func<T, bool>> expression, string include = null)
        {
            var task = Task.Run(() =>
            {
                IQueryable<T> query = _db;
                if (include != null)
                    query.Include(include);
                return query.Where(expression).AsNoTracking().FirstOrDefault();
            });
            task.Wait();
            return task.Result;
        }

        public void Add (T entity)
        {
            var task = Task.Run(() =>
            {
                _db.Add(entity);
                _dbContext.SaveChanges();
            });
            task.Wait();
        }

        public void Update(T entity)
        {
            var task = Task.Run(() =>
            {
                _db.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            });
            task.Wait();
        }

        public void Delete(int id)
        {
            var task = Task.Run(() =>
            {
                var entity = _db.Find(id);
                _db.Remove(entity);
                _dbContext.SaveChanges();
            });
            task.Wait();
        }
    }
}