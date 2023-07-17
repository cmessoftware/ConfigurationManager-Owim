using AutoMapper;
using ConfigurationManager.Dto;
using ConfigurationManager.Mappers;
using ConfigurationManager.Models;
using ConfigurationManager.Services;
using System.Web.Http;

namespace ConfigurationManager.Controllers
{
    public class ApplicationController : ApiController
    {
        private readonly IMapper _mapper;

        public ApplicationController()
        {
            _mapper = AutoMapperConfig.InitializeAutomapper();
        }

        [HttpGet]
        [Route("applications")]
        public IHttpActionResult Get()
        { 
            var service = new ApplicationService();
            var response = service.GetAll();
            return Json(response);
        }

        [HttpGet]
        [Route("applications/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var service = new ApplicationService();
            var response = service.GetById(id);
            return Json(response);
        }

        [HttpPost]
        [Route("application/create")]
        public IHttpActionResult Create([FromBody] RequestDto<ApplicationDto> appDto)
        {

            var application = _mapper.Map<Application>(appDto);
            var service = new ApplicationService();
            var response = service.Create(application);

            return Json(response);
        }

        [HttpPut]
        [Route("application/update")]
        public IHttpActionResult Update([FromBody] RequestDto<ApplicationDto> appDto)
        {

            var application = _mapper.Map<Application>(appDto);
            var service = new ApplicationService();
            var response = service.Update(application);

            return Json(response);
        }
    }
}
