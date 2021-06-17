using BulkyBook.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BulkuBook.DataAccess.IRepository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();

        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperty = null)
        {
            IQueryable<T> query = dbset;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }

            if(includeProperty != null)
            {
                foreach (var inclProp in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inclProp);
                }
            }
            return query.ToList();
        }

        public T GetSingleOrDefault(Expression<Func<T, bool>> filter = null, string includeProerty = null)
        {
            
            IQueryable<T> query = dbset;
             if(filter != null)
             {
                query = query.Where(filter);
             }

             if(includeProerty != null)
             {
                foreach (var inclProp in includeProerty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inclProp);
                }
             }
          return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T obj = dbset.Find(id);
            Remove(obj);
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
