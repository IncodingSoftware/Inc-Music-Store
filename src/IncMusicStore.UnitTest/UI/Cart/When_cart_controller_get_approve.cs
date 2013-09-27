namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(CartController))]
    public class When_cart_controller_get_approve
    {
        #region Estabilish value

        static MockController<CartController> mockController;

        static ActionResult result;

        static GetCurrentCartQuery query;

        static Cart expected;

        #endregion

        Establish establish = () =>
                                  {
                                      query = Pleasure.Generator.Invent<GetCurrentCartQuery>();
                                      expected = Pleasure.Generator.Invent<Cart>(dsl => dsl.Callback(cart =>
                                                                                                         {
                                                                                                             cart.AddItem(Pleasure.Generator.Invent<CartItem>(factoryDsl => factoryDsl.GenerateTo<Album>(s => s.Album)));
                                                                                                             cart.AddItem(Pleasure.Generator.Invent<CartItem>(factoryDsl => factoryDsl.GenerateTo<Album>(s => s.Album)));
                                                                                                         }));

                                      mockController = MockController<CartController>
                                              .When()
                                              .StubQuery(query, expected);
                                  };

        Because of = () => { result = mockController.Original.Approve(query); };

        It should_be_result = () => result.ShouldBeIncodingSuccess();

        It should_be_render = () =>
                                  {
                                      Action<ApproveCartCommand> predicateItems = cartCommand => cartCommand.Items.ShouldEqualWeakEach(expected.Items, (dsl, i) => dsl.ForwardToValue(r => r.Album, expected.Items[i].Album.Title)
                                                                                                                                                                      .ForwardToValue(r => r.Quantity, expected.Items[i].Quantity.ToString()));
                                      mockController.ShouldBeRenderModel<ApproveCartCommand>(command => command.ShouldEqualWeak(expected, dsl => dsl.ForwardToValue(r => r.CartId, expected.Id.ToString())
                                                                                                                                                    .IgnoreBecauseNotUse(r => r.PromoCode)
                                                                                                                                                    .IgnoreBecauseNotUse(r => r.PostalCode)
                                                                                                                                                    .IgnoreBecauseNotUse(r => r.Address)
                                                                                                                                                    .IgnoreBecauseNotUse(r => r.City)
                                                                                                                                                    .IgnoreBecauseNotUse(r => r.Country)
                                                                                                                                                    .IgnoreBecauseNotUse(r => r.Phone)
                                                                                                                                                    .IgnoreBecauseNotUse(r => r.State)
                                                                                                                                                    .ForwardToAction(r => r.Items, predicateItems)));
                                  };
    }
}