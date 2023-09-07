using AppConfigurationManager.Data;
using AppConfigurationManager.Models;
using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AppConfigurationManager.Repository
{
    internal class RoleRepository : GenericRepository<AppRole>, IRoleRepository
    {
        private static ILog _log = LogManager.GetLogger(typeof(UserRepository));
        private readonly CMDbContext _context;
        public RoleRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<AppRole> GetById(int? id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<List<AppRole>> GetAll()
        {
            return await base.GetAll();
        }

        public async Task<bool> Create(AppRole rol)
        {
            try
            {
                if (rol == null)
                {
                    return false;
                }

                await base.Create(rol);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;

            }
        }

        public async Task<bool> Update(AppRole rol)
        {

            try
            {
                if (rol == null)
                {
                    return false;
                }

                await base.Update(rol);

                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;

            }

        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                return await base.Delete(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;

            }
        }
    }
}