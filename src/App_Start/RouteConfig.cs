using System.Web.Mvc;
using System.Web.Routing;

namespace blogapi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            MapPostRoutes(routes);
        }

        private static void MapPostRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "CreatePost",
                url: "post",
                defaults: new { controller = "Post", action = "CreatePost" }
            );
        }
    }
}