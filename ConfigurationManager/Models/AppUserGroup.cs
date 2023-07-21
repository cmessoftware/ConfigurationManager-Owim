using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppConfigurationManager.Models
{
    public class AppUserGroup
    {
        [StringLength(36)]
        public string UserGroupId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<AppUser> User { get; set; }

    }
}