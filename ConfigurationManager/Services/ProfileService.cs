using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConfigurationManager.Controllers
{
    internal class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;


        public ProfileService()
        {
            _profileRepository = new ProfileRepository();

        }
        public async Task<bool> Create(AppProfile pf)
        {
            return await _profileRepository.Create(pf);
        }

        public async Task<bool> Delete(string id)
        {
            return await _profileRepository.Delete(id);

        }

        public async Task<List<AppProfile>> GetAll()
        {
            var response = await _profileRepository.GetAll();
            return response;
        }

        public async Task<AppProfile> GetById(string id)
        {
            var response = await _profileRepository.GetById(id);
            return response;
        }

        public async Task<bool> Update(AppProfile pf)
        {
            return await _profileRepository.Update(pf);
        }

        public bool Exists(AppProfile pf)
        {
            return _profileRepository.Exists(pf);
        }

        public async Task<AppProfile> GetByName(string name)
        {
            var response = await _profileRepository.GetByName(name);
            return response;
        }
    }
}