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

    public class GenreController : IncControllerBase
    {
        #region Constructors

        public GenreController(IDispatcher dispatcher)
                : base(dispatcher) { }

        #endregion

        #region Http action

        [HttpGet]
        public ActionResult Fetch()
        {
            var vms = this.dispatcher
                          .Query(new GetEntitiesQuery<Genre>())
                          .Select(r => new GenreVm(r))
                          .ToList();

            return IncJson(vms);
        }

        [HttpGet]
        public ActionResult FetchForDD()
        {
            var vms = this.dispatcher
                          .Query(new GetEntitiesQuery<Genre>())
                          .Select(r => new KeyValueVm(r.Id, r.Name))
                          .ToList();

            return IncJson(vms);
        }

        #endregion
    }
}