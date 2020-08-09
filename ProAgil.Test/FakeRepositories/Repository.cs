using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProAgil.Test.FakeRepositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IList<T> _context;

        public Repository(IList<T> context)
        {
            _context = context;
        }
        public Task Add(T entity)
        {
            _context.Add(entity);
            var id = new Random().Next(1, 100);
            entity.Id = id;
            return Task.FromResult(_context);
        }
        public void Update(T entity)
        {
            var index = GetIndexFromEntity(entity);
            _context[index] = entity;
        }
        public void Delete(T entity)
        {
            var index = GetIndexFromEntity(entity);
            _context.RemoveAt(index);
        }
         public void DeleteRange(T[] entity)
        {
            foreach (var item in entity)
            {
                 var index = GetIndexFromEntity(item);
                 _context.RemoveAt(index);
            }
        }
        public Task<T[]> Get()
        {
            return Task.FromResult(_context.ToArray());
        }
        public Task<T[]> Find(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(_context.AsQueryable().Where(predicate).ToArray());
        }
        public Task<bool> SaveChanges()
        {
            return Task.FromResult(_context.Count > 0);
        }

        private int GetIndexFromEntity(T entity)
        {
            return entity.Id - 1;
        }
    }
}
