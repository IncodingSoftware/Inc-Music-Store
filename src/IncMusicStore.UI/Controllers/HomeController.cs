namespace IncMusicStore.UI.Controllers
{
    #region << Using >>

    using System.Web.Mvc;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    #endregion

    public class HomeController : IncControllerBase
    {
        #region Constructors

        public HomeController(IDispatcher dispatcher)
                : base(dispatcher) { }

        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}