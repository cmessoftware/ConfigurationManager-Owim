using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppConfigurationManager.Models
{
    public class AppRole : BaseModel
    {
        [StringLength(36)]
        public string RoleId { get; set; } = Guid.NewGuid().ToString();
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public List<AppUser> Users { get; set; }

    }
}