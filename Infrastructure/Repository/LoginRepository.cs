using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class LoginRepository : ILogin
{
    protected readonly PaginaContext _context;

    public LoginRepository(PaginaContext context){
        _context = context;
    }

    public void Add(Login entity)
    {
        _context.Set<Login>().Add(entity);
    }

    public void AddRange(IEnumerable<Login> entities)
    {
        _context.Set<Login>().AddRange(entities);
    }

    public IEnumerable<Login> Find(Expression<Func<Login, bool>> expression)
    {
        return _context.Set<Login>().Where(expression);
    }

    public async Task<IEnumerable<Login>> GetAllAsync()
    {
        return await _context.Set<Login>().ToListAsync();
    }

    public async Task<Login> GetByIdAsync(int Id)
    {
        return (await _context.Set<Login>().FindAsync(Id))!;
    }

    public void Remove(Login entity)
    {
        _context.Set<Login>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Login> entities)
    {
        _context.Set<Login>().RemoveRange(entities);
    }

    public void Update(Login entity)
    {
        _context.Set<Login>().Update(entity);
    }
}
