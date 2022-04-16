namespace Infra.Repository;

public interface IRepository<T> where T: class
{

    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Remove(T entity);
}