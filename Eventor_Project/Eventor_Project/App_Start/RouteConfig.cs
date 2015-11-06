using System.Web.Mvc;
using System.Web.Routing;

namespace Eventor_Project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Editt",                                           // Route name
                "Archive/{id}",                            // URL with parameters
                new { controller = "User", action = "Edit" }  // Parameter defaults
            );

            routes.MapRoute(
                "UserInfo",
                "id/{id}",
                new { controller = "User", action = "Info", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Users",
                "Users",
                new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "My Profile",
                "im/{action}",
                new { controller = "User", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}