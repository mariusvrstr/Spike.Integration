using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Spike.Integration.Web.AuthenticationHandlers;
using Swashbuckle.Application;

namespace Spike.Integration.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;

            // Forces browser to return JSON
            formatters.Remove(formatters.XmlFormatter);

            var jsonFormatter = formatters.JsonFormatter;

            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // config.Filters.Add(new WebApiExceptionFilter()); // Handle Web API Exceptions
            config.Filters.Add(new BasicAuthenticationAttribute()); // Handles basic authentication

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //GlobalConfiguration.Configuration
            //    .EnableSwagger(c => c.SingleApiVersion("v1", "Sample Web API "))
            //    .EnableSwaggerUi();
        }
    }
}
