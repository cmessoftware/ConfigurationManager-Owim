using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetById(string id);
        Task<T> GetByName(string name);
        Task<List<T>> GetAll();
        Task<bool> Create(T entity);
        Task<bool> Delete(string id);
        Task<bool> Update(T entity);
    }
}
