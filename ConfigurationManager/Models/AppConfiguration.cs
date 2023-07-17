using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager.Models
{
    public class AppConfiguration
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ApplicationId { get; set; }

        //Navegation property.
        public Application Application { get; set; }
    }
}
