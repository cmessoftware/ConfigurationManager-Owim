using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Services
{
    public class ApplicationService : IApplicationService
    {

        private readonly IApplicationRepository _appRepository;
      

        public ApplicationService()
        {
            _appRepository = new ApplicationRepository();
            
        }
        public async Task<bool> Create(Application app)
        {

            if(!_appRepository.Exists(app))
                return  await _appRepository.Create(app);
            else
                return false;
        }

        public async Task<bool> Delete(string id)
        {
           return await _appRepository.Delete(id);

        }

        public async Task<List<Application>> GetAll()
        {
            var response =  await _appRepository.GetAll();
            return response;
        }

        public async Task<Application> GetById(string id)
        {
            var response =  await _appRepository.GetById(id);
            return response;
        }

        public async Task<bool> Update(Application application)
        {
            return await _appRepository.Update(application);
        }

        public bool Exists(Application application)
        {
            return  _appRepository.Exists(application);
        }

        public async Task<Application> GetByName(string name)
        {
            var response = await _appRepository.GetByName(name);
            return response;
        }
    }
}
