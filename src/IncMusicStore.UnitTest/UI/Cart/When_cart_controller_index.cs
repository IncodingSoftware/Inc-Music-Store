namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using IncMusicStore.UI.Models;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(CartController))]
    public class When_cart_controller_index
    {
        #region Estabilish value

        static MockController<CartController> mockController;

        static ActionResult result;

        static CartItem cartItem;

        #endregion

        Establish establish = () =>
                                  {
                                      var query = Pleasure.Generator.Invent<GetCurrentCartQuery>();
                                      var cart = Pleasure.Generator.Invent<Cart>(dsl => dsl.Callback(r =>
                                                                                                         {
                                                                                                             var inventAlbum = Pleasure.Generator.Invent<Album>(inventFactoryDsl => inventFactoryDsl.Tuning(album => album.Price, (decimal)3));
                                                                                                             cartItem = Pleasure.Generator.Invent<CartItem>(factoryDsl => factoryDsl.Tuning(item => item.Quantity, 5)
                                                                                                                                                                                    .Tuning(item => item.Album, inventAlbum));
                                                                                                             r.AddItem(cartItem);
                                                                                                             r.AddItem(cartItem);
                                                                                                         }));

                                      mockController = MockController<CartController>
                                              .When()
                                              .StubQuery(query, cart);
                                  };

        Because of = () => { result = mockController.Original.Index(); };

        It should_be_result = () => result.ShouldBeOfType<ViewResult>();

        It should_be_model = () =>
                                 {
                                     var cartItems = Pleasure.ToReadOnly(cartItem, cartItem);
                                     Action<IndexCartVm> predicateItems = cartVm => cartVm.Items.ShouldEqualWeakEach(cartItems, (dsl, i) => dsl.ForwardToValue(r => r.Price, cartItems[i].Album.Price.ToMoney())
                                                                                                                                               .ForwardToValue(r => r.Quantity, cartItems[i].Quantity.ToString())
                                                                                                                                               .ForwardToValue(r => r.Cost, (decimal)15)
                                                                                                                                               .ForwardToValue(r => r.Album, cartItems[i].Album.Title));
                                     result.ShouldBeModel<IndexCartVm>(vm => vm.ShouldEqualWeak(new { Total = (decimal)30 }, dsl => dsl.ForwardToAction(r => r.Items, predicateItems)));
                                 };
    }
}