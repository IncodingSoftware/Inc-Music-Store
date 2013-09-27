namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(CartController))]
    public class When_cart_controller_add_item
    {
        #region Estabilish value

        static MockController<CartController> mockController;

        static ActionResult result;

        static AddCartItemCommand input;

        #endregion

        Establish establish = () =>
                                  {
                                      input = Pleasure.Generator.Invent<AddCartItemCommand>();

                                      mockController = MockController<CartController>
                                              .When();
                                  };

        Because of = () => { result = mockController.Original.AddItem(input); };

        It should_be_success = () => result.ShouldBeIncodingSuccess();

        It should_be_push = () => mockController.ShouldBePush(input);
    }
}