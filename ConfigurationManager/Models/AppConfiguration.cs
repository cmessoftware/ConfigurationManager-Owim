using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigurationManager.Models
{
    public class AppConfiguration : BaseModel
    {
        [StringLength(36)]
        public string AppConfigurationId { get; set; } = Guid.NewGuid().ToString();
        public string Key { get; set; }
        public string Value { get; set; }
        public string ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
