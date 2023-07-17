using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigurationManager.Services
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
                //TODO: Setear datos de auditoria.

                return await _genericRepository.Create(entity);
            }

            public async Task<bool> Delete(int? id)
            {
                //TODO: Setear datos de auditoria.
                return await _genericRepository.Delete(id);
            }

            public Task<List<TEntity>> GetAll()
            {
                //TODO: Setear datos de auditoria.
                return _genericRepository.GetAll();
            }

            public async Task<TEntity> GetById(int? id)
            {
                //TODO: Setear datos de auditoria.
                return await _genericRepository.GetById(id);
            }

            public async Task<bool> Update(TEntity entity)
            {
                //TODO: Setear datos de auditoria.
                return await _genericRepository.Update(entity);
            }

        }
}
