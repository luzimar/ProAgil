using ProAgil.Domain.Core.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProAgil.Domain.Core.Interfaces
{
    public interface IRepository<T> where T: Entity
    {
         Task Add(T entity);
         void Update(T entity);
         void Delete(T entity);
         Task<T[]> Get();
         Task<T[]> Find(Expression<Func<T, bool>> predicate);
         Task<bool> SaveChanges();
    }
}