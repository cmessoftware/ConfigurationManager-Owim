﻿using AppConfigurationManager.Models;

namespace AppConfigurationManager.Dto
{
    public class EnvironmentDto
    {
        public string Name { get; set; }
        public EnumEnviromentType Type { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}