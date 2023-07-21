using AutoMapper;
using AppConfigurationManager.Dto;
using AppConfigurationManager.Models;
using System;
using CM = AppConfigurationManager.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;
using AppConfigurationManager.Controllers;

namespace AppConfigurationManager.Mappers
{
    public class AutoMapperConfig
        {

            private static IMapper _mapper;

            public static IMapper InitializeAutomapper()
            {
                //Provide all the Mapping Configuration
                var config = new MapperConfiguration(cfg =>
                {
                //Configuring mappings
                    cfg.CreateMap<ApplicationDto, Application>()
                        .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                        .ForMember(dst => dst.Description, src => src.MapFrom(x => x.Description))
                        .ForMember(dst => dst.Version, src => src.MapFrom(x => x.Version))
                        .ForMember(dst => dst.Environments, src => src.MapFrom(x => x.Environments))
                        .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                        .ForMember(dst => dst.Configurations, src => src.Ignore())
                        .ForMember(dst => dst.CreateOn, src => src.MapFrom(x => DateTime.Now))
                        .ForMember(dst => dst.UpdateOn, src => src.MapFrom(x => DateTime.Now))
                        .ForMember(dst => dst.CreateBy, src => src.Ignore())
                        .ForMember(dst => dst.UpdateBy, src => src.Ignore());
                  

                    cfg.CreateMap<EnvironmentDto, AppEnvironment>();
                    cfg.CreateMap<ConfigurationDto, AppConfiguration>();
                    cfg.CreateMap<UserDto, AppUser>();
                    cfg.CreateMap<RoleDto, AppRole>();
                    cfg.CreateMap<ProfileDto, AppProfile>();


                });

                //Create an Instance of Mapper and return that Instance

                _mapper = _mapper ?? new Mapper(config);
                return _mapper;
            }
        }
    }


