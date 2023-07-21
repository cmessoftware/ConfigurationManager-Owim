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
    public class ProfileController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private static ILog _log = LogManager.GetLogger(typeof(ProfileController));
        private readonly ProfileService _profileService;


        public ProfileController()
        {
            _mapper = AutoMapperConfig.InitializeAutomapper();
            _profileService = new ProfileService();
        }

        [HttpGet]
        [Route("profiles")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var response = await _profileService.GetAll();
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpGet]
        [Route("profile/{id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var response = await _profileService.GetById(id);
                return CreateResponse(response);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPost]
        [Route("profile/create")]
        public async Task<IHttpActionResult> Create([FromBody] RequestDto<ProfileDto> usrDto)
        {
            try
            {
                var pf = _mapper.Map<AppProfile>(usrDto.Data);
                var response = await _profileService.Create(pf);

                if (response)
                    return CreateResponse<bool>(response);
                else
                    return CreateErrorResponse<bool>(response, 
                           GetErrorDto($"The profile {pf.Name} already exists"));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPut]
        [Route("profile/update")]
        public async Task<IHttpActionResult> Update([FromBody] RequestDto<ProfileDto> pfDto)
        {
            try
            {
                var pf = _mapper.Map<AppProfile>(pfDto.Data);
                var response = await _profileService.Update(pf);

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
