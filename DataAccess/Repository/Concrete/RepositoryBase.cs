
using DataAccess.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository.Concrete
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly SchoolDbContext _db;
        internal DbSet<T> _dbSet;
        public RepositoryBase(SchoolDbContext db)
        {
            _db = db; 
            _dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            query = AddIncludeOperationToQueryIfIncludePropertiesIsNotNull(query, includeProperties);

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            query = AddIncludeOperationToQueryIfIncludePropertiesIsNotNull(query, includeProperties);

            return query.FirstOrDefault();
        }

        static IQueryable<T> AddIncludeOperationToQueryIfIncludePropertiesIsNotNull(IQueryable<T> query, string? includeProperties)
        {
            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(prop);
            }
            return query;
        }
    }
}
