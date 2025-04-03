using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIBasketApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configuração para JSON por padrão
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }
    }
}
