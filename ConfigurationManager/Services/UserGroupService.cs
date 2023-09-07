using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Controllers
{
    internal class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;


        public UserGroupService()
        {
            _userGroupRepository = new UserGroupRepository();

        }
        public async Task<bool> Create(AppUserGroup usr)
        {
            return await _userGroupRepository.Create(usr);
        }

        public async Task<bool> Delete(string id)
        {
            return await _userGroupRepository.Delete(id);

        }

        public async Task<List<AppUserGroup>> GetAll()
        {
            var response = await _userGroupRepository.GetAll();
            return response;
        }

        public async Task<AppUserGroup> GetById(string id)
        {
            var response = await _userGroupRepository.GetById(id);
            return response;
        }

        public async Task<bool> Update(AppUserGroup usr)
        {
            return await _userGroupRepository.Update(usr);
        }

        public bool Exists(AppUserGroup usr)
        {
            return _userGroupRepository.Exists(usr);
        }

        public async Task<AppUserGroup> GetByName(string name)
        {
            var response = await _userGroupRepository.GetByName(name);
            return response;
        }
    }
}