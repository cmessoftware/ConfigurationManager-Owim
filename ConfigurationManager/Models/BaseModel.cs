using System;

namespace AppConfigurationManager.Models
{
    public class BaseModel
    {
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        

    }
}