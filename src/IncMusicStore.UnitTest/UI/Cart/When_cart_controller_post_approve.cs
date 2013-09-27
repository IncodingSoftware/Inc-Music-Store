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
    public class When_cart_controller_post_approve
    {
        #region Estabilish value

        static MockController<CartController> mockController;

        static ActionResult result;

        static ApproveCartCommand input;

        #endregion

        Establish establish = () =>
                                  {
                                      input = Pleasure.Generator.Invent<ApproveCartCommand>();

                                      mockController = MockController<CartController>
                                              .When();
                                  };

        Because of = () => { result = mockController.Original.Approve(input); };

        It should_be_success = () => result.ShouldBeIncodingSuccess();

        It should_be_push = () => mockController.ShouldBePush(input);
    }
}