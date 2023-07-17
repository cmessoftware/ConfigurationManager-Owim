using CacheManager.Core.Logging;
using ConfigurationManager.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;


namespace ConfigurationManager.Services
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(GenericRepository<TEntity>));
        protected readonly CMDbContext _context;

        protected GenericRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<TEntity> GetById(int? id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public async Task<bool> Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
            return true;
        }


        public async Task<bool> Delete(int? id)
        {

            try
            {
                var entity = await GetById(id);
                if (entity == null) return false;

                var enEntryRemove = _context.Set<TEntity>().Remove(entity);
                if (enEntryRemove == null) return false;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                    return false;
                else
                {
                    _context.Set<TEntity>().AddOrUpdate(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }

        }

    }
}