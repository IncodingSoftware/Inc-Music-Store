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

    [IncMusicStoreAuthorize]
    public class CartController : IncControllerBase
    {
        #region Constructors

        public CartController(IDispatcher dispatcher)
                : base(dispatcher) { }

        #endregion

        #region Http action

        [HttpGet]
        public ActionResult AddItem(AddCartItemCommand input)
        {
            /*            if (!ModelState.IsValid)
                return IncodingResult.Error(ModelState);

            try
            {
                this.dispatcher.Push(input);
                return IncodingResult.Success();
            }
            catch (IncWebException incWebException)
            {
                ModelState.AddModelError(incWebException.Property, incWebException.Message);
                return IncodingResult.Error(ModelState);
            }*/
            return TryPush(input); // above show how it work in depth
        }

        [HttpGet]
        public ActionResult Approve(GetCurrentCartQuery query)
        {
            var cart = this.dispatcher.Query(query);
            return IncView(new ApproveCartCommand(cart));
        }

        [HttpPost]
        public ActionResult Approve(ApproveCartCommand input)
        {
            return TryPush(input); // above show how it work in depth
        }

        [HttpPost]
        public ActionResult Delete(DeleteEntityByIdCommand input)
        {
            return TryPush(input);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var cart = this.dispatcher.Query(new GetCurrentCartQuery());
            return View(new IndexCartVm
                            {
                                    Items = cart.Items.Select(r => new CartItemVm(r)).ToList()
                            });
        }

        #endregion
    }
}