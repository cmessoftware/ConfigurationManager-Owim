using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public int RoleId { get; set; }
        public List<AppRole> AppRoles { get; set; }
        public int PermissionId { get; set; }

        public List<AppPermission> AppPermissions { get; set; }

    }
}
