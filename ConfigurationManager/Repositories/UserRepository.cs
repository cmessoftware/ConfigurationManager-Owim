using AppConfigurationManager.Data;
using AppConfigurationManager.Models;
using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AppConfigurationManager.Repository
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        private static ILog _log = LogManager.GetLogger(typeof(UserRepository));
        private readonly CMDbContext _context;
        public UserRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<AppUser> GetById(int? id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<AppUser>> GetAll()
        {
            return await base.GetAll();
        }

        public async Task<bool> Create(AppUser usr)
        {
            try
            {
                if (usr == null)
                {
                    return false;
                }

                await base.Create(usr);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;

            }
        }

        public async Task<bool> Update(AppUser usr)
        {

            try
            {
                if (usr == null)
                {
                    return false;
                }

                await base.Update(usr);

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