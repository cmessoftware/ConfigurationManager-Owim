using System.Collections.Generic;

namespace ConfigurationManager.Models
{
    public class AppPermission
    {
        public int Id { get; set; }
        public EnumPermissions Type { get; set; }
        public string Description { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}