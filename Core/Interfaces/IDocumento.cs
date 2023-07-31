using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

    public interface IDocumento
    {
        Task<Documento > ? GetByIdAsync(int Id);
        Task<IEnumerable<Documento >> GetAllAsync();
        IEnumerable<Documento > Find(Expression<Func<Documento ,bool>> expression);
        void Add(Documento  entity);
        void AddRange(IEnumerable<Documento > entities);
        void Remove(Documento  entity);
        void RemoveRange(IEnumerable<Documento > entities);
        void Update(Documento  entity);
    }
