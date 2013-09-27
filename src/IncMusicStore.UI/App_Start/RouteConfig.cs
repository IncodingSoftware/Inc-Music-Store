namespace IncMusicStore.UI.App_Start
{
    #region << Using >>

    using System.Web.Mvc;
    using System.Web.Routing;

    #endregion

    ////ncrunch: no coverage start
    public class RouteConfig
    {
        #region Factory constructors

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                            name: "Default", 
                            url: "{controller}/{action}/{id}", 
                            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                    );
        }

        #endregion
    }

    ////ncrunch: no coverage end
}