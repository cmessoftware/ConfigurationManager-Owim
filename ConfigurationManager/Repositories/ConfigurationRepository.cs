using AppConfigurationManager.Models;
using AppConfigurationManager.Services;

namespace AppConfigurationManager.Repository
{
    public class ConfigurationRepository : GenericRepository<AppConfiguration>, IConfigurationRepository
    {
    }
}