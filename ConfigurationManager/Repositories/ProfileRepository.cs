using AppConfigurationManager.Data;
using AppConfigurationManager.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Repository
{
    internal class ProfileRepository : GenericRepository<AppProfile>, IProfileRepository
    {
        private static ILog _log = LogManager.GetLogger(typeof(ProfileRepository));
        private readonly CMDbContext _context;
        public ProfileRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<AppProfile> GetById(int? id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<List<AppProfile>> GetAll()
        {
            return await base.GetAll();
        }

        public async Task<bool> Create(AppProfile pf)
        {
            try
            {
                if (pf == null)
                {
                    return false;
                }

                await base.Create(pf);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;

            }
        }

        public async Task<bool> Update(AppProfile pf)
        {

            try
            {
                if (pf == null)
                {
                    return false;
                }

                await base.Update(pf);

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