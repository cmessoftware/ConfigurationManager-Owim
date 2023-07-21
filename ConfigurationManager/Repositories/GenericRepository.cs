using CacheManager.Core.Logging;
using AppConfigurationManager.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;

namespace AppConfigurationManager.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(GenericRepository<TEntity>));
        protected readonly CMDbContext _context;

        protected GenericRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<TEntity> GetById(string id)
        {
             return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> Create(TEntity entity)
        {
             _context.Set<TEntity>().Add(entity);
             return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Delete(string id)
        {
            var entity = await GetById(id);
            if (entity == null) return false;

            var enEntryRemove = _context.Set<TEntity>().Remove(entity);
            if (enEntryRemove == null) return false;

            await _context.SaveChangesAsync();

            return true;
     
        }

        public async Task<bool> Update(TEntity entity)
        {
            if (entity == null)
                return false;
            else
            {
                _context.Set<TEntity>().AddOrUpdate(entity);
                _context.SaveChanges();
                return true;
            }
        }

        public async Task<TEntity> GetByName(string name)
        {
            return await _context.Set<TEntity>().FindAsync(name);
        }

        public bool Exists(TEntity entity)
        {
            return _context.Set<TEntity>().Count() > 0;
        }
    }
}