using EpamLibrary.DAL.EF;
using EpamLibrary.DAL.Entities.Abstract;
using EpamLibrary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EpamLibrary.DAL.Repositories
{
    /// <summary>
    /// generic repository for all classes that inherrits from AbstractDbObject
    /// </summary>
    public class GenericRepository<T> : IRepository<T> where T : AbstractDbObject
    {
        private readonly ApplicationContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// get item by id
        /// </summary>
        public T GetById(int id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);

            return entity;
        }

        /// <summary>
        /// get list of items with certain expressions
        /// </summary>
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            var query = _dbSet as IQueryable<T>;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        /// <summary>
        /// creates new item
        /// </summary>
        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// updates item
        /// </summary>
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// deletes item
        /// </summary>
        public void Delete(int id)
        {
            var obj = _dbSet.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (obj is null)
                return;
            _dbSet.Remove(obj);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
