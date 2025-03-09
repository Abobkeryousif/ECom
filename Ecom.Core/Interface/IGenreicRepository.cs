using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interface
{
    public interface IGenreicRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] include);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id,params Expression<Func<T, object>>[] include);
        Task AddAsync(T entitie);
        Task UpdateAsync(T entitie);
        Task DeleteAsync(int Id);
    }
}
