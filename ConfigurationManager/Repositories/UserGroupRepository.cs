using AppConfigurationManager.Data;
using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AppConfigurationManager.Controllers
{
    internal class UserGroupRepository : GenericRepository<AppUserGroup>, IUserGroupRepository
    {
        private static ILog _log = LogManager.GetLogger(typeof(UserGroupRepository));
        private readonly CMDbContext _context;
        public UserGroupRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<AppUserGroup> GetById(int? id)
        {
            return await _context.UserGroups.FindAsync(id);
        }

        public async Task<List<AppUserGroup>> GetAll()
        {
            return await base.GetAll();
        }

        public async Task<bool> Create(AppUserGroup rol)
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

        public async Task<bool> Update(AppUserGroup rol)
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