using CacheManager.Core.Logging;
using ConfigurationManager.Data;
using ConfigurationManager.Models;
using log4net;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigurationManager.Services
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {

        private static ILog _log = LogManager.GetLogger(typeof(ApplicationRepository));

        public ApplicationRepository()
        {

        }

        //public Task<Application> GetById(int? id) 
        //{ 
        //}
        Task<List<Application>> GetAll()
        { 
            return base.GetAll();
        }

        //Task<bool> Create(T entity);
        //Task<bool> Delete(int? id);
        //Task<bool> Update(T entity);


    }
}