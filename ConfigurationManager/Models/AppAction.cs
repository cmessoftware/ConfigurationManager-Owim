using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppConfigurationManager.Models
{
    public class AppAction : BaseModel
    {
        [StringLength(36)]
        public string ActionId { get; set; } = Guid.NewGuid().ToString();
        public EnumAction Type { get; set; }
        public string Description { get; set; }

        public List<AppUser> Users { get; set; }
    }
}