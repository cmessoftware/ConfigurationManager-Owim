using ConfigurationManager.Models;

namespace ConfigurationManager.Dto
{
    public class AppEnvironmentDto
    {
        public string Name { get; set; }
        public EnumEnviromentType Type { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}