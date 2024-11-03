using System.Linq.Expressions;

namespace DriversManagement.API.Interfaces;

public interface IRepository
{
    IQueryable<T> GetAll<T>() where T : class;
    Task Add<T>(T entity) where T : class;
    Task Update<T>(T entity) where T : class;
    Task Delete<T>(T entity) where T : class;
    Task<T?> GetById<T>(int id) where T : class; 
    Task<ICollection<T>> Search<T>(Expression<Func<T, bool>> predicate) where T : class;
}