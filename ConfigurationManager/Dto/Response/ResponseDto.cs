using System.Collections.Generic;

namespace AppConfigurationManager.Dto
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public List<ErrorDto> Errors{get;set;}
    }
}