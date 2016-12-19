using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Api.Classic
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            config.Services.Replace(typeof(IHttpControllerSelector), new Strategy2ControllerSelector(config));
        }
    }
}