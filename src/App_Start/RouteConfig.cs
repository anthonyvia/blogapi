using System.Web.Http;
using System.Web.Routing;

namespace BlogApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            MapPostRoutes(routes);
        }

        private static void MapPostRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "CreatePost",
                routeTemplate: "post",
                defaults: new { controller = "Post", action = "CreatePost" }
            );

            routes.MapHttpRoute(
                name: "GetPost",
                routeTemplate: "post/{id}",
                defaults: new { controller = "post", action = "GetPost" }
            );
        }
    }
}