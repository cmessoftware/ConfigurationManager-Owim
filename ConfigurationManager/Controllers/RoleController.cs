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
    public class RoleController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private static ILog _log = LogManager.GetLogger(typeof(RoleController));
        private readonly RoleService _roleService;


        public RoleController()
        {
            _mapper = AutoMapperConfig.InitializeAutomapper();
            _roleService = new RoleService();
        }

        [HttpGet]
        [Route("applications")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var response = await _roleService.GetAll();
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
                var response = await _roleService.GetById(id);
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
        public async Task<IHttpActionResult> Create([FromBody] RequestDto<RoleDto> roleDto)
        {
            try
            {
                var role = _mapper.Map<AppRole>(roleDto.Data);
                var response = await _roleService.Create(role);

                if (response)
                    return CreateResponse<bool>(response);
                else
                    return CreateErrorResponse<bool>(response, 
                           GetErrorDto($"The application {role.RoleName} already exists"));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return CreateErrorResponse(false, GetErrorDto(ex));
            }
        }

        [HttpPut]
        [Route("application/update")]
        public async Task<IHttpActionResult> Update([FromBody] RequestDto<RoleDto> roleDto)
        {
            try
            {
                var application = _mapper.Map<AppRole>(roleDto.Data);
                var response = await _roleService.Update(application);

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
