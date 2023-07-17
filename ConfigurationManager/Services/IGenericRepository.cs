using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigurationManager.Services
{ 
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int? id);
        Task<List<T>> GetAll();
        Task<bool> Create(T entity);
        Task<bool> Delete(int? id);
        Task<bool> Update(T entity);
    }
}