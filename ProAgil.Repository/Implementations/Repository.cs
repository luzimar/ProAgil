using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository.Context;
using ProAgil.Repository.Interfaces;

namespace ProAgil.Repository.Implementations
{
  public abstract class Repository<T> : IRepository<T> where T : class
  {
    protected readonly ProAgilContext _context;

    public Repository(ProAgilContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    public async Task Add(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
    }
    public void Update(T entity)
    {
       _context.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
       _context.Set<T>().Remove(entity);
    }
    public async Task<T[]> Get()
    {
      return await _context.Set<T>().ToArrayAsync();
    }
    public async Task<T[]> Find(Expression<Func<T, bool>> predicate)
    {
       return await _context.Set<T>().Where(predicate).ToArrayAsync();
    }
    public async Task<bool> SaveChanges()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}