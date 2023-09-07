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
    public class ConfigurationController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private static ILog _log = LogManager.GetLogger(typeof(ConfigurationController));
        private readonly ConfigurationService _configService;


        public ConfigurationController()
        {
            _mapper = AutoMapperConfig.InitializeAutomapper();
            _configService = new ConfigurationService();
        }

        [HttpGet]
        [Route("configurations")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var response = await _configService.GetAll();
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpGet]
        [Route("configuration/{id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var response = await _configService.GetById(id);
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPost]
        [Route("configuration/create")]
        public async Task<IHttpActionResult> Create([FromBody] RequestDto<ConfigurationDto> configDto)
        {
            try
            {
                var config = _mapper.Map<AppConfiguration>(configDto.Data);
                var response = await _configService.Create(config);

                if (response)
                    return CreateResponse(response);
                else
                    return CreateErrorResponse<bool>(response, 
                           GetErrorDto($"The Key {config.Key} already exists"));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPut]
        [Route("configuration/update")]
        public async Task<IHttpActionResult> Update([FromBody] RequestDto<ConfigurationDto> configDto)
        {
            try
            {
                var config = _mapper.Map<AppConfiguration>(configDto.Data);
                var response = await _configService.Update(config);

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
