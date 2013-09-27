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

    public class AlbumController : IncControllerBase
    {
        #region Constructors

        public AlbumController(IDispatcher dispatcher)
                : base(dispatcher) { }

        #endregion

        #region Http action

        [HttpGet]
        public ActionResult Details(GetAlbumQuery query)
        {
            var vm = new AlbumDetailsVm(this.dispatcher.Query(query));
            return IncView(vm);
        }

        [HttpGet]
        public ActionResult FetchTopSelling()
        {
            var vms = this.dispatcher
                          .Query(new GetAlbumsTopSellingQuery())
                          .Select(r => new AlbumTopSellingVm(r))
                          .ToList();

            return IncJson(vms);
        }

        #endregion
    }
}