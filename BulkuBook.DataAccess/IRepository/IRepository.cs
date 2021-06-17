using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BulkuBook.DataAccess.IRepository
{
    public interface IRepository<T>  where  T:class
    {

        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperty = null
            );
        T GetSingleOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProerty = null
            );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
        
    }
}
