using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class DocumentoRepository : IDocumento
{
    private PaginaContext _context;

    public DocumentoRepository(PaginaContext context)
    {
        _context = context;
    }

    public void Add(Documento entity)
    {
        _context.Set<Documento>().Add(entity);
    }

    public void AddRange(IEnumerable<Documento> entities)
    {
        _context.Set<Documento>().AddRange(entities);
    }

    public IEnumerable<Documento> Find(Expression<Func<Documento, bool>> expression)
    {
        return  _context.Set<Documento>().Where(expression);
    }

    public async Task<IEnumerable<Documento>> GetAllAsync()
    {
        return await _context.Set<Documento>().ToListAsync();
    }

    public async Task<Documento>? GetByIdAsync(int Id)
    {
        return (await _context.Set<Documento>().FindAsync(Id))!;
    }

    public void Remove(Documento entity)
    {
        _context.Set<Documento>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Documento> entities)
    {
        _context.Set<Documento>().RemoveRange(entities);
    }

    public void Update(Documento entity)
    {
        _context.Set<Documento>().Update(entity);
    }
}
