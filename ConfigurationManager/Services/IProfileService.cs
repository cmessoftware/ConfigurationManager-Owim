using AppConfigurationManager.Models;
using AppConfigurationManager.Repository;
using AppConfigurationManager.Services;

namespace AppConfigurationManager.Controllers
{
    internal interface IProfileService : IGenericService<AppProfile>
    {
    }
}