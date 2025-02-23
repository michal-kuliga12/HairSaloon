using System.Linq.Expressions;

namespace HairSaloon.DataAccess.Repository.IRepository;

// TODO - Dodać implementacje Repository która będzie zawierać metody generyczne
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    T Get(Expression<Func<T, bool>> predicate, string? includeProperties = null);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entites);
}
