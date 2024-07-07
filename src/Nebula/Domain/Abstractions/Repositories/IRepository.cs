using System.Linq.Expressions;

namespace Nebula.Domain.Abstractions.Repositories;

public interface IRepository<T> where T : class
{
    T? Get(Expression<Func<T, bool>> filter);
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
}