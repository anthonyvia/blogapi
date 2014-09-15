using System.Web.Http;
using System.Web.Routing;

namespace blogapi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            MapPostRoutes(routes);
        }

        private static void MapPostRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "CreatePost",
                routeTemplate: "post",
                defaults: new { controller = "Post", action = "CreatePost" }
            );
        }
    }
}