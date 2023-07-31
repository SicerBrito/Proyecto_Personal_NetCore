using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

    public interface ITelefono
    {
        Task<Telefono> ? GetByIdAsync(int Id);
        Task<IEnumerable<Telefono>> GetAllAsync();
        IEnumerable<Telefono> Find(Expression<Func<Telefono,bool>> expression);
        void Add(Telefono entity);
        void AddRange(IEnumerable<Telefono> entities);
        void Remove(Telefono entity);
        void RemoveRange(IEnumerable<Telefono> entities);
        void Update(Telefono entity);
        
        
    }
