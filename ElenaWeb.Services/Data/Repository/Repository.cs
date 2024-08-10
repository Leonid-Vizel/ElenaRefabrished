using FRDZSchool.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FRDZSchool.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _db;

        internal DbSet<T> dbSet;

        public Repository(ApplicationContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public IIncludableQueryable<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> path)
            => dbSet.Include(path);
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
            => dbSet.Select(selector);
        public IQueryable<T> Where(Expression<Func<T, bool>> filter)
            => dbSet.Where(filter);
        public async Task<TResult?> GetField<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector, CancellationToken token = default)
            => await dbSet.Where(filter).Select(selector).FirstOrDefaultAsync(token);
        public async Task AddAsync(T value, CancellationToken token = default)
            => await dbSet.AddAsync(value, token);
        public async Task AddRangeAsync(IEnumerable<T> values, CancellationToken token = default)
            => await dbSet.AddRangeAsync(values, token);
        public async Task<int> CountAsync(CancellationToken token = default)
            => await dbSet.CountAsync(token);
        public async Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
            => await dbSet.CountAsync(filter, token);
        public async Task<bool> AnyAsync(CancellationToken token = default)
            => await dbSet.AnyAsync(token);
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
            => await dbSet.AnyAsync(filter, token);
        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
            => await dbSet.FirstOrDefaultAsync(filter, token);
        public void Remove(T value)
            => dbSet.Remove(value);
        public void Update(T value)
            => dbSet.Update(value);
        public void RemoveRange(IEnumerable<T> value)
            => dbSet.RemoveRange(value);
        public void UpdateRange(IEnumerable<T> value)
            => dbSet.UpdateRange(value);
        public async Task SaveAsync(CancellationToken token = default)
            => await _db.SaveChangesAsync(token);
        public IOrderedQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> sort)
            => dbSet.OrderBy(sort);
        public IOrderedQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> sort)
            => dbSet.OrderByDescending(sort);
    }
}
