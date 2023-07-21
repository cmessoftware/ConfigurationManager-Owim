using AppConfigurationManager.Controllers;
using AppConfigurationManager.Data;
using AppConfigurationManager.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigurationManager.Repository
{
    public class EnvironmentRepository : GenericRepository<AppEnvironment>, IEnvironmentRepository
    {

        private static ILog _log = LogManager.GetLogger(typeof(EnvironmentRepository));
        private readonly CMDbContext _context;
        public EnvironmentRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<AppEnvironment> GetById(int? id)
        {
            return await _context.Environments.FindAsync(id);
        }

        public async Task<List<AppEnvironment>> GetAll()
        {
                return await base.GetAll();
        }

        public async Task<bool> Create(AppEnvironment env)
        {
            try
            {
                if (env == null)
                {
                    return false;
                }

                await base.Create(env);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;

            }
        }

        public async Task<bool> Update(AppEnvironment app)
        {

            try
            {
                if (app == null)
                {
                    return false;
                }

                await base.Update(app);

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