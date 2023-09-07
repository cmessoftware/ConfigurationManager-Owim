using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigurationManager.Models
{
    public class AppUser 
    {
        [Key, StringLength(36)]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
     
        public List<AppRole> Roles { get; set; }
        public List<Application> Applications { get; set; }
        public List<AppUserGroup> UserGroups { get; set; }
        public string CreateBy_UserId { get; set; }
        public string UpdateBy_UserId { get; set; }

    }
}
