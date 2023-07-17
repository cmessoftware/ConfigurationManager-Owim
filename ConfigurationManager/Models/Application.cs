using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager.Models
{
    public class Application : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public List<AppEnvironment> AppEnvironments { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public int UserId { get; internal set; }
        public int EnvironmentId { get; internal set; }
    }
}
