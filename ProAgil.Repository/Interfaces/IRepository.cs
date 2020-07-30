using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProAgil.Repository.Interfaces
{
    public interface IRepository<T> where T: class
    {
         Task Add(T entity);
         void Update(T entity);
         void Delete(T entity);
         Task<T[]> Get();
         Task<T[]> Find(Expression<Func<T, bool>> predicate);
         Task<bool> SaveChanges();
    }
}