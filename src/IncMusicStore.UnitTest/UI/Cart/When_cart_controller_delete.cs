namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.UI.Controllers;
    using Incoding.CQRS;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(CartController))]
    public class When_cart_controller_delete
    {
        #region Estabilish value

        static MockController<CartController> mockController;

        static ActionResult result;

        static DeleteEntityByIdCommand input;

        #endregion

        Establish establish = () =>
                                  {
                                      input = Pleasure.Generator.Invent<DeleteEntityByIdCommand>();

                                      mockController = MockController<CartController>
                                              .When();
                                  };

        Because of = () => { result = mockController.Original.Delete(input); };

        It should_be_success = () => result.ShouldBeIncodingSuccess();

        It should_be_push = () => mockController.ShouldBePush(input);
    }
}