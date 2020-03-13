using EpamLibrary.DAL.EF;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.Tables.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EpamLibrary.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : AbstractDbObject
    {
        private readonly ApplicationContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T GetById(int id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);

            return entity;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            var query = _dbSet as IQueryable<T>;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public void Delete(int id)
        //{
        //    var toRm = _dbSet.Find(id);
        //    if (toRm != null)
        //    {
        //        toRm.IsDeleted = true;
        //        Update(toRm);
        //        //_dbSet.Remove(toRm); //TODO: is deleted
        //    }

        //    _context.SaveChanges();
        //}
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
