using AppConfigurationManager.Models;
using AppConfigurationManager.Services;
using System.Threading.Tasks;

namespace AppConfigurationManager.Repository
{
    public interface IEnvironmentRepository : IGenericRepository<AppEnvironment>
    {
    }
}