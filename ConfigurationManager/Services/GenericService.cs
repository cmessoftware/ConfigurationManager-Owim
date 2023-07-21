using AppConfigurationManager.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Services
{
    public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
        {
            private readonly IGenericRepository<TEntity> _genericRepository;

            public GenericService(IGenericRepository<TEntity> genericRepository)
            {
                this._genericRepository = genericRepository;
            }


            public async Task<bool> Create(TEntity entity)
            {
                return await _genericRepository.Create(entity);
            }

            public async Task<bool> Delete(string id)
            {
                return await _genericRepository.Delete(id);
            }

            public Task<List<TEntity>> GetAll()
            {
                return _genericRepository.GetAll();
            }

            public async Task<TEntity> GetById(string id)
            {
                return await _genericRepository.GetById(id);
            }

        public async Task<TEntity> GetByName(string name)
        {
           return await _genericRepository.GetByName(name);
        }

        public async Task<bool> Update(TEntity entity)
            {
                
                return await _genericRepository.Update(entity);
            }

        }
}
