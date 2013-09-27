namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Web;
    using Incoding.Maybe;

    #endregion

    ////ncrunch: no coverage start
    public class HttpSessionContext : ISessionContext
    {
        #region ISessionContext Members

        public string UserId
        {
            get { return HttpContext.Current.Request.Cookies["userId"].ReturnOrDefault(r => r.Value, string.Empty); }
            set { HttpContext.Current.Response.Cookies.Add(new HttpCookie("userId", value)); }
        }

        #endregion
    }

    ////ncrunch: no coverage end
}