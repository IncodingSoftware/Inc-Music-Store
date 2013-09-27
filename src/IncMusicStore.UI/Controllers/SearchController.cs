namespace IncMusicStore.UI.Controllers
{
    #region << Using >>

    using System.Linq;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Models;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    #endregion

    public class SearchController : IncControllerBase
    {
        #region Constructors

        public SearchController(IDispatcher dispatcher)
                : base(dispatcher) { }

        #endregion

        #region Http action

        [HttpGet]
        public ActionResult Fetch(SearchAlbumQuery query)
        {
            var vms = this.dispatcher
                          .Query(query)
                          .Select(r => new AlbumDetailsVm(r))
                          .ToList();
            return IncJson(vms);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}