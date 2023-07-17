using ConfigurationManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigurationManager.Services
{
    public class ApplicationService : IApplicationService
    {

        private readonly IApplicationRepository _appRepository;
      

        public ApplicationService()
        {
            _appRepository = new ApplicationRepository();
            
        }
        public Task<bool> Create(Application entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Application>> GetAll()
        {
            var repo = new ApplicationRepository();
            var response =  await repo.GetAll();
            return response;
        }

        public Task<Application> GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Application entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
