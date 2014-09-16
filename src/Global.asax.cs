using System.Web.Http;
using System.Web.Routing;
using StructureMap;
using WebApiContrib.IoC.StructureMap;

namespace BlogApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IContainer container = TypeRegistry.RegisterTypes();

            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapResolver(container);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}