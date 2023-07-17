using ConfigurationManager.Helpers;
using Microsoft.Owin;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

[assembly: OwinStartup(typeof(ConfigurationManager.App_Start.Startup))]

namespace ConfigurationManager.App_Start
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            app.UseWebApi(config);

            WebApiConfig.Register(config);

            if (ConfigurationHelper.GetConfig("EnableSwagger").ToUpper() == "TRUE")
            {
                config.EnableSwagger(options =>
                {
                    options.SingleApiVersion("v1", "Configuration Manager");
                    options.UseFullTypeNameInSchemaIds();
                    //c.IncludeXmlComments(GetXmlCommentsPath());
                }).EnableSwaggerUi();
            }

            app.UseWebApi(config);

        }
    }
    public class CustomDirectRouteProvider : DefaultDirectRouteProvider
    {
        protected override IReadOnlyList<IDirectRouteFactory>
        GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
        {
            // inherit route attributes decorated on base class controller's actions
            return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>
            (inherit: true);
        }
    }
}
