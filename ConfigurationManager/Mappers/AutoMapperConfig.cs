using AutoMapper;
using ConfigurationManager.Dto;
using ConfigurationManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager.Mappers
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
                    cfg.CreateMap<Application, ApplicationDto>();
                    
                });

                //Create an Instance of Mapper and return that Instance

                _mapper = _mapper ?? new Mapper(config);
                return _mapper;
            }
        }
    }


