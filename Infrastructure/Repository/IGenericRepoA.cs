namespace Infrastructure.Repository;

    public class IGenericRepoA
    {
    public interface IGenericRepoA1<T> where T : BaseEntityA
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }

    }
