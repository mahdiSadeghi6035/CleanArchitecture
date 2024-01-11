using System.Linq.Expressions;

namespace BlogManagement.Application.Common.Contracts.Persistence;

public interface IGenericRepository<TKey, T>  where T : class
{
    Task<T> Get(TKey id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task Delete(T entity);
    Task<T> Update(T entity);
    Task<bool> Exist(Expression<Func<T, bool>> expression);
    Task SaveChanges();
}
