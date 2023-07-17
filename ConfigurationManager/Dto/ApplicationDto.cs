using ConfigurationManager.Models;
using System.Collections.Generic;

namespace ConfigurationManager.Dto
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public List<AppEnvironmentDto> AppEnvironments { get; set; }
    }
}