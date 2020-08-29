using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Core.Models;
using ProAgil.Infra.Data.Context;
using ProAgil.Infra.Data.Context.Base;

namespace ProAgil.Infra.Data.Implementations
{
    public class Repository<T> : BaseContext, IRepository<T> where T : Entity
    {
        public Repository(ProAgilContext context) : base(context)
        { }

        public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public void DeleteRange(T[] entity) => _context.Set<T>().RemoveRange(entity);
        public async Task<T[]> Get() => await _context.Set<T>().ToArrayAsync();
        public async Task<T[]> Find(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToArrayAsync();
        public async Task<bool> SaveChanges() => await _context.SaveChangesAsync() > 0;
    }
}