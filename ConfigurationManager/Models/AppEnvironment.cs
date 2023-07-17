namespace ConfigurationManager.Models
{
    public class AppEnvironment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumEnviromentType Type { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}