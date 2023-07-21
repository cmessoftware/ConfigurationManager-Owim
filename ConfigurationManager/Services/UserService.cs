using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService()
        {
            _userRepository = new UserRepository();

        }
        public async Task<bool> Create(AppUser usr)
        {
            return await _userRepository.Create(usr);
        }

        public async Task<bool> Delete(string id)
        {
            return await _userRepository.Delete(id);

        }

        public async Task<List<AppUser>> GetAll()
        {
            var response = await _userRepository.GetAll();
            return response;
        }

        public async Task<AppUser> GetById(string id)
        {
            var response = await _userRepository.GetById(id);
            return response;
        }

        public async Task<bool> Update(AppUser usr)
        {
            return await _userRepository.Update(usr);
        }

        public bool Exists(AppUser usr)
        {
            return _userRepository.Exists(usr);
        }

        public async Task<AppUser> GetByName(string name)
        {
            var response = await _userRepository.GetByName(name);
            return response;
        }
    }
}