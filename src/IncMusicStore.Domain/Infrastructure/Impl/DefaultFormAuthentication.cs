namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Web;
    using System.Web.Security;

    #endregion

    public class DefaultFormAuthentication : IFormAuthentication
    {
        ////ncrunch: no coverage start
        #region IFormAuthentication Members

        public void SignIn(string login, string id, bool persistence)
        {
            const int countPersistence = 10;
            var expiration = persistence ? DateTime.Now.AddDays(countPersistence) : DateTime.Now.AddMinutes(countPersistence);
            string encryptTick = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, login, DateTime.Now, expiration, true, id));

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTick);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public bool IsAuthentication()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        #endregion

        ////ncrunch: no coverage end   
    }
}