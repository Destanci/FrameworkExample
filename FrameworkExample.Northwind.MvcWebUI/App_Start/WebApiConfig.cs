using System.Web.Http;

namespace FrameworkExample.Northwind.MvcWebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Product", id = RouteParameter.Optional }
            );
        }
    }
}
