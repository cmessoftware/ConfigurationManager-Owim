using System;

namespace ConfigurationManager.Helpers
{
    public class ConfigurationHelper
    {

        public static string  GetConfig(string key)
        {
            var val =  System.Configuration.ConfigurationManager.AppSettings[key];

            return val;
        }
    }
}