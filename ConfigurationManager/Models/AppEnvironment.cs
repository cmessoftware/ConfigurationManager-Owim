using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppConfigurationManager.Models
{
    public class AppEnvironment : BaseModel
    {
        [Key, StringLength(36)]
        public string AppEnvironmentId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public EnumEnviromentType Type { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<Application> Applications { get; set; }
    }
}