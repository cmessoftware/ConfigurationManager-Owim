using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using AppConfigurationManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Controllers
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configRepository;


        public ConfigurationService()
        {
            _configRepository = new ConfigurationRepository();

        }
        public async Task<bool> Create(AppConfiguration config)
        {

            //if (!_configRepository.Exists(config))
                return await _configRepository.Create(config);
            //else
            //    return false;
        }

        public async Task<bool> Delete(string id)
        {
            return await _configRepository.Delete(id);

        }

        public async Task<List<AppConfiguration>> GetAll()
        {
            var response = await _configRepository.GetAll();
            return response;
        }

        public async Task<AppConfiguration> GetById(string id)
        {
            var response = await _configRepository.GetById(id);
            return response;
        }

        public async Task<bool> Update(AppConfiguration config)
        {
            return await _configRepository.Update(config);
        }

        public bool Exists(AppConfiguration config)
        {
            return _configRepository.Exists(config);
        }

        public async Task<AppConfiguration> GetByName(string name)
        {
            var response = await _configRepository.GetByName(name);
            return response;
        }
    }
}