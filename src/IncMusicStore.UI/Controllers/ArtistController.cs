namespace IncMusicStore.UI.Controllers
{
    #region << Using >>

    using System.Linq;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    #endregion

    public class ArtistController : IncControllerBase
    {
        #region Constructors

        public ArtistController(IDispatcher dispatcher)
                : base(dispatcher) { }

        #endregion

        #region Http action

        [HttpGet]
        public ActionResult FetchForDD()
        {
            var vms = this.dispatcher.Query(new GetEntitiesQuery<Artist>())
                          .Select(r => new KeyValueVm(r.Id, r.Name))
                          .ToList();
            return IncJson(vms);
        }

        #endregion
    }
}