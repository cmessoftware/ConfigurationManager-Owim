using System.Collections.Generic;

namespace ConfigurationManager.Models
{
    public class AppRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; }
        public EnumRoleId RoleId { get; set; }
        public List<AppUser> AppUsers { get; set; }

    }
}