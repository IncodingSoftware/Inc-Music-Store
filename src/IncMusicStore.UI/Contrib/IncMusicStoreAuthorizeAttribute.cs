namespace IncMusicStore.UI
{
    #region << Using >>

    using System;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using Incoding.Block.IoC;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    #endregion

    ////ncrunch: no coverage start
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IncMusicStoreAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var formAuthentication = IoCFactory.Instance.TryResolve<IFormAuthentication>();
            if (!formAuthentication.IsAuthentication())
            {
                formAuthentication.SignOut();
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            var dispatcher = IoCFactory.Instance.TryResolve<IDispatcher>();
            var sessionContext = IoCFactory.Instance.TryResolve<ISessionContext>();

            var currentUser = dispatcher.Query(new GetEntityByIdQuery<User>(sessionContext.UserId));
            if (currentUser == null)
            {
                formAuthentication.SignOut();
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var urlHelper = new UrlHelper(filterContext.RequestContext);

            string url = urlHelper.Action("SignIn", "Account");
            filterContext.Result = filterContext.RequestContext.HttpContext.Request.IsAjaxRequest()
                                           ? (ActionResult)IncodingResult.RedirectTo(url)
                                           : new RedirectResult(url);
        }
    }

    ////ncrunch: no coverage end
}