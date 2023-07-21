using AppConfigurationManager.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace AppConfigurationManager.Controllers
{
    public class ApiBaseController : ApiController
    {
        public IHttpActionResult CreateResponse<T>(T response)
        {
            return Json(new ResponseDto<T>()
            {
                Data = response
            });
        }

        public IHttpActionResult CreateErrorResponse<T>(T response,List<ErrorDto> errors)
        {
            return Json(new ResponseDto<T>()
            {
                Data = response,
                Errors = errors
                
            });
        }

        public static List<ErrorDto> GetErrorDto(string message)
        {
            var errors = new List<ErrorDto>()
                              {
                                new ErrorDto()
                                    {
                                        Code = HttpStatusCode.BadRequest.ToString(),
                                        Message = message
                                }
            };

            return errors;
        }

        public static List<ErrorDto> GetErrorDto(Exception ex)
        {
            var errors = new List<ErrorDto>()
                              {
                                new ErrorDto()
                                    {
                                        Code = ex.Source,
                                        Message = ex.InnerException != null ?
                                                  $"{ex.Message} : {ex.InnerException.Message} " :
                                                  ex.Message                                
                                } 
            };

            return errors;
        }

    }
}