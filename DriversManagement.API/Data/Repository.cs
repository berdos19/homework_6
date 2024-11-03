using DriversManagement.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DriversManagement.API.Data;

public class Repository : IRepository
{
    private readonly MariaDbContext _context;

    public Repository(MariaDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }
    public async Task Add<T>(T entity) where T : class
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete<T>(T entity) where T : class
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetById<T>(int id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<ICollection<T>> Search<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }
}