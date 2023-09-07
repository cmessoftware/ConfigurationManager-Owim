using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppConfigurationManager.Models
{
    public class AppProfile
    {
        [Key, StringLength(36)]
        public string ProfileId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Application> Applications { get; set; }
        public List<AppUserGroup> UserGroups { get; set; }

    }
}