using System.Collections.Generic;

namespace ConfigurationManager.Dto
{
    public class ResultDto<T>
    {
        public T Data { get; set; }

        public List<ErrorDto> Errors{get;set;}
    }
}