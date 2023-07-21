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
    public class EnvironmentController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private static ILog _log = LogManager.GetLogger(typeof(EnvironmentController));
        private readonly EnvironmentService _envService;

        public EnvironmentController()
        {
            _mapper = AutoMapperConfig.InitializeAutomapper();
            _envService = new EnvironmentService();
        }

        [HttpGet]
        [Route("environments")]
        public async Task<IHttpActionResult> Get()
        { 
            try
            { 
            var response = await _envService.GetAll();
            return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpGet]
        [Route("environment/{id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var response = await _envService.GetById(id);
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpGet]
        [Route("environment/name:string")]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            try
            {
                var response = await _envService.GetByName(name);
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }


        [HttpPost]
        [Route("environment/create")]
        public async Task<IHttpActionResult> Create([FromBody] RequestDto<EnvironmentDto> envDto)
        {
            try
            {
                var env = _mapper.Map<AppEnvironment>(envDto.Data);
                var response = await _envService.Create(env);

                if (response)
                    return CreateResponse(response);
                else
                    return CreateErrorResponse<bool>(response, 
                           GetErrorDto($"The environment {env.Name} already exists"));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPut]
        [Route("environment/update")]
        public async Task<IHttpActionResult> Update([FromBody] RequestDto<EnvironmentDto> envDto)
        {
            try
            {
                var env = _mapper.Map<AppEnvironment>(envDto.Data);
                var response = await _envService.Update(env);

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
