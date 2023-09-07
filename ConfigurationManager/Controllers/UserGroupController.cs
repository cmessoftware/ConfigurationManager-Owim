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
    public class UserGroupController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private static ILog _log = LogManager.GetLogger(typeof(UserGroupController));
        private readonly UserGroupService _userGroupService;


        public UserGroupController()
        {
            _mapper = AutoMapperConfig.InitializeAutomapper();
        }

        [HttpGet]
        [Route("applications")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var response = await _userGroupService.GetAll();
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
                var response = await _userGroupService.GetById(id);
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
        public async Task<IHttpActionResult> Create([FromBody] RequestDto<UserGroupDto> usrDto)
        {
            try
            {
                var user = _mapper.Map<AppUserGroup>(usrDto.Data);
                var response = await _userGroupService.Create(user);

                if (response)
                    return CreateResponse<bool>(response);
                else
                    return CreateErrorResponse<bool>(response, 
                           GetErrorDto($"The user group {user.Name} already exists"));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPut]
        [Route("application/update")]
        public async Task<IHttpActionResult> Update([FromBody] RequestDto<UserGroupDto> usrDto)
        {
            try
            {
                var user = _mapper.Map<AppUserGroup>(usrDto.Data);
                var response = await _userGroupService.Update(user);

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
