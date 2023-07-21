using AppConfigurationManager.Models;
using System.Collections.Generic;

namespace AppConfigurationManager.Dto
{
    public class ApplicationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public List<EnvironmentDto> Environments { get; set; }

    }
}