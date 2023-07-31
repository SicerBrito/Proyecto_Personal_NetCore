using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

    public interface ILogin
    {
        Task<Login> ? GetByIdAsync(int Id);
        Task<IEnumerable<Login>> GetAllAsync();
        IEnumerable<Login> Find(Expression<Func<Login,bool>> expression);
        void Add(Login entity);
        void AddRange(IEnumerable<Login> entities);
        void Remove(Login entity);
        void RemoveRange(IEnumerable<Login> entities);
        void Update(Login entity);
    }
