﻿
using System.Linq.Expressions;

namespace DataAccess.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null );
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
    }
}
