using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using AppConfigurationManager.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Controllers
{
    internal class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository _envRepository;


        public EnvironmentService()
        {
            _envRepository = new EnvironmentRepository();

        }
        public async Task<bool> Create(AppEnvironment env)
        {

            if (!_envRepository.Exists(env))
                return await _envRepository.Create(env);
            else
                return false;
        }

        public async Task<bool> Delete(string id)
        {
            return await _envRepository.Delete(id);

        }

        public async Task<List<AppEnvironment>> GetAll()
        {
            var response = await _envRepository.GetAll();
            return response;
        }

        public async Task<AppEnvironment> GetById(string id)
        {
            var response = await _envRepository.GetById(id);
            return response;
        }

        public async Task<bool> Update(AppEnvironment env)
        {
            return await _envRepository.Update(env);
        }

        public bool Exists(AppEnvironment env)
        {
            return _envRepository.Exists(env);
        }

        public async Task<AppEnvironment> GetByName(string name)
        {
            return await  _envRepository.GetByName(name);
        }
    }
}
