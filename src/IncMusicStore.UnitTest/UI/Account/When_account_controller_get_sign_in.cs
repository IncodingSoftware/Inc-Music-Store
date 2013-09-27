namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.UI.Controllers;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AccountController))]
    public class When_account_controller_get_sign_in
    {
        #region Estabilish value

        static MockController<AccountController> mockController;

        static ActionResult result;

        #endregion

        Establish establish = () =>
                                  {
                                      mockController = MockController<AccountController>
                                              .When();
                                  };

        Because of = () => { result = mockController.Original.SignIn(); };

        It should_be_result = () => result.ShouldBeOfType<ViewResult>();
    }
}