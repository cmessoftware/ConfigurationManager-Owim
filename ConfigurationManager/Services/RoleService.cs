using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using AppConfigurationManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Services
{
    internal class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;


        public RoleService()
        {
            _roleRepository = new RoleRepository();

        }
        public async Task<bool> Create(AppRole rol)
        {
            return await _roleRepository.Create(rol);
        }

        public async Task<bool> Delete(string id)
        {
            return await _roleRepository.Delete(id);

        }

        public async Task<List<AppRole>> GetAll()
        {
            var response = await _roleRepository.GetAll();
            return response;
        }

        public async Task<AppRole> GetById(string id)
        {
            var response = await _roleRepository.GetById(id);
            return response;
        }

        public async Task<bool> Update(AppRole usr)
        {
            return await _roleRepository.Update(usr);
        }

        public bool Exists(AppRole rol)
        {
            return _roleRepository.Exists(rol);
        }

        public async Task<AppRole> GetByName(string name)
        {
            var response = await _roleRepository.GetByName(name);
            return response;
        }
    }

}