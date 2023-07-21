using AppConfigurationManager.Data;
using AppConfigurationManager.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Repository
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {

        private static ILog _log = LogManager.GetLogger(typeof(ApplicationRepository));
        private readonly CMDbContext _context;
        public ApplicationRepository()
        {
            _context = new CMDbContext();
        }

        public async Task<Application> GetById(int? id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task<List<Application>> GetAll()
        {
            return await base.GetAll();
        }

        public async Task<bool> Create(Application app)
        {
            try
            {
                if (app == null)
                {
                    return false;
                }

                await base.Create(app);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;

            }
        }

        public async Task<bool> Update(Application app)
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