using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IInfoPersonal 
    {
        Task<InfoPersonal > ? GetByIdAsync(int Id);
        Task<IEnumerable<InfoPersonal >> GetAllAsync();
        IEnumerable<InfoPersonal > Find(Expression<Func<InfoPersonal ,bool>> expression);
        void Add(InfoPersonal  entity);
        void AddRange(IEnumerable<InfoPersonal > entities);
        void Remove(InfoPersonal  entity);
        void RemoveRange(IEnumerable<InfoPersonal > entities);
        void Update(InfoPersonal  entity);
    }
}