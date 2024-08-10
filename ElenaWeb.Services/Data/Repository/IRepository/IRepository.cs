using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FRDZSchool.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        IIncludableQueryable<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> path);
        Task<TResult?> GetField<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector, CancellationToken token = default);
        Task AddAsync(T value, CancellationToken token = default);
        Task AddRangeAsync(IEnumerable<T> values, CancellationToken token = default);
        void Remove(T value);
        void RemoveRange(IEnumerable<T> value);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
        Task<int> CountAsync(CancellationToken token = default);
        Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
        Task<bool> AnyAsync(CancellationToken token = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
        void Update(T value);
        void UpdateRange(IEnumerable<T> value);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector);
        IQueryable<T> Where(Expression<Func<T, bool>> filter);
        IOrderedQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> sort);
        IOrderedQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> sort);
    }
}
