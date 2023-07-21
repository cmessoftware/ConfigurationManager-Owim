using AppConfigurationManager.Dto;
using AppConfigurationManager.Mappers;
using AppConfigurationManager.Models;
using AppConfigurationManager.Services;
using AutoMapper;
using log4net;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppConfigurationManager.Controllers
{
    public class ApplicationController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private static ILog _log = LogManager.GetLogger(typeof(ApplicationController));
        private readonly ApplicationService _appService;


        public ApplicationController()
        {
            _mapper = AutoMapperConfig.InitializeAutomapper();
        }

        [HttpGet]
        [Route("applications")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var response = await _appService.GetAll();
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpGet]
        [Route("application/{id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var response = await _appService.GetById(id);
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPost]
        [Route("application/create")]
        public async Task<IHttpActionResult> Create([FromBody] RequestDto<ApplicationDto> appDto)
        {
            try
            {
                var application = _mapper.Map<Application>(appDto.Data);
                var response = await _appService.Create(application);

                if (response)
                    return CreateResponse<bool>(response);
                else
                    return CreateErrorResponse<bool>(response, 
                           GetErrorDto($"The application {application.Name} already exists"));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPut]
        [Route("application/update")]
        public async Task<IHttpActionResult> Update([FromBody] RequestDto<ApplicationDto> appDto)
        {
            try
            {
                var application = _mapper.Map<Application>(appDto.Data);
                var response = await _appService.Update(application);

                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }
    }
}
