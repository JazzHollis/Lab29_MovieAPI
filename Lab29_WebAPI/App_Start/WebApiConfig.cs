using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab29_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Removes the XML formatter, so the next one will be JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //This line will stop the infinite loop caused by the navigation properties
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",//action helps us enable multiple actions
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
