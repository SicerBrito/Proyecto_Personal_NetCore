
// namespace Infrastructure.Repository
// {
//     public interface GenericRepositoryA
//     {

//     }
//     public virtual async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string _search){
//         var totalRegistros = await _context.Set<T>().CountAsync();
//         var registros = await _context.Set<T>()
//             .Skip((pageIndex - 1) * pageSize)
//             .Take(pageSize)
//             .ToListAsync();
//         return (totalRegistros, registros);
//     }
// }