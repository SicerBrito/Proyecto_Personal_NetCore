using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class InfoPersonalRepository : IInfoPersonal
{
    protected readonly PaginaContext _context;
    public InfoPersonalRepository(PaginaContext context)
    {
        _context = context;
    }

    public void Add(InfoPersonal entity)
    {
        _context.Set<InfoPersonal>().Add(entity);
    }

    public void AddRange(IEnumerable<InfoPersonal> entities)
    {
        _context.Set<InfoPersonal>().AddRange(entities);
    }

    public IEnumerable<InfoPersonal> Find(Expression<Func<InfoPersonal, bool>> expression)
    {
        return  _context.Set<InfoPersonal>().Where(expression);
    }

    public async Task<IEnumerable<InfoPersonal>> GetAllAsync()
    {
        return await _context.Set<InfoPersonal>().ToListAsync();
    }

    public async Task<InfoPersonal> GetByIdAsync(int Id)
    {
        return (await _context.Set<InfoPersonal>().FindAsync(Id))!;
    }

    public void Remove(InfoPersonal entity)
    {
        _context.Set<InfoPersonal>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<InfoPersonal> entities)
    {
        _context.Set<InfoPersonal>().RemoveRange(entities);
    }

    public void Update(InfoPersonal entity)
    {
        _context.Set<InfoPersonal>().Update(entity);
    }
}
