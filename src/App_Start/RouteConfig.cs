using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo
{
    public class RouteConfig
    {
        //RegisterRoutes called once from the Global.asax.cs file when the application is first run.
        //the default route pattern is specified here and added to the RouteCollection.
        //custom routes can also be added here if required
        public static void RegisterRoutes(RouteCollection routes)
        {
            //===========================================================
            //requests that match the string passed to IgnoreRoute
            //are not handled by our MVC Controllers.
            //requests that contain .axd file extensions
            //are handled by another HttpHandler that is only 
            //responsible for serving up resources such as js/css
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //===========================================================


            //===========================================================
            //inside the above call to MapRoute()
            //the url parameter specifies the url after the domain name
            //and would appear www.domainname.com/controller/action/id
            //values inside the placeholders { } will be substituted when the request is received.
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            //the defaults parameter represents the default path if no additional url is provided after
            //the www.domainname.com would result in the route path /home/index with an optional id parameter.
        }
    }
}
