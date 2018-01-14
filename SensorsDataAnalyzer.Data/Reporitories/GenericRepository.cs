using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorsDataAnalyzer.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new ApplicationDbContext();
            _dbSet = _context.Set<T>();
        }
        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual T Update(T entity)
        {
            var existing = _dbSet.FirstOrDefault(item => item.Id == entity.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).Property("AddedDate").IsModified = false;
            }
            return existing;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
