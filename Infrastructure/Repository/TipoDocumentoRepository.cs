using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TipoDocumentoRepository : ITipoDocumento
{
    protected readonly PaginaContext _context;

    public TipoDocumentoRepository(PaginaContext context){
        _context = context;
    }

    public void Add(TipoDocumento entity)
    {
        _context.Set<TipoDocumento>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoDocumento> entities)
    {
        _context.Set<TipoDocumento>().AddRange(entities);
    }

    public IEnumerable<TipoDocumento> Find(Expression<Func<TipoDocumento, bool>> expression)
    {
        return _context.Set<TipoDocumento>().Where(expression);
    }

    public async Task<IEnumerable<TipoDocumento>> GetAllAsync()
    {
        return await _context.Set<TipoDocumento>().ToListAsync();
    }

    public async Task<TipoDocumento> GetByIdAsync(int Id)
    {
        return (await _context.Set<TipoDocumento>().FindAsync(Id))!;
    }

    public void Remove(TipoDocumento entity)
    {
        _context.Set<TipoDocumento>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoDocumento> entities)
    {
        _context.Set<TipoDocumento>().RemoveRange(entities);
    }

    public void Update(TipoDocumento entity)
    {
        _context.Set<TipoDocumento>().Update(entity);
    }
}
