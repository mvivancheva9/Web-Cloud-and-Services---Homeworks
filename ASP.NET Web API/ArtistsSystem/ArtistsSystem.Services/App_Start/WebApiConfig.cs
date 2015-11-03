namespace ArtistsSystem.Services
{
    using System.Web.Http;
    using Newtonsoft.Json;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters
            //    .JsonFormatter
            //    .SerializerSettings
            //    .PreserveReferencesHandling = PreserveReferencesHandling.None;
            // remove xml formatter
            //config.Formatters
            //    .Remove(config.Formatters.XmlFormatter);
        }
    }
}
