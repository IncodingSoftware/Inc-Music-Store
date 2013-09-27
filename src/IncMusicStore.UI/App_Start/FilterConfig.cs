namespace IncMusicStore.UI.App_Start
{
    #region << Using >>

    using System.Web.Mvc;

    #endregion

    ////ncrunch: no coverage start
    public class FilterConfig
    {
        #region Factory constructors

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }

    ////ncrunch: no coverage end
}