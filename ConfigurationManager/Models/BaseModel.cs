using System;

namespace ConfigurationManager.Models
{
    public class BaseModel
    {
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; } = DateTime.Now;
        public AppUser CreateBy { get; set; }
        public AppUser ModifiyBy { get; set; }
        

    }
}