using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppConfigurationManager.Models
{
    public class Application : BaseModel
    {
        [Key, StringLength(36)]
        public string ApplicationId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public List<AppEnvironment> Environments { get; set; }
        public List<AppConfiguration> Configurations { get; set; }

    }
}
