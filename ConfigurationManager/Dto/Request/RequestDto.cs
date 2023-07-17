using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager.Dto
{ 
    public class RequestDto<T>
    {
        public T Data { get; set; }

    }
}
