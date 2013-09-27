namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AccountController))]
    public class When_account_controller_post_sign_in
    {
        #region Estabilish value

        static MockController<AccountController> mockController;

        static ActionResult result;

        static SignInUserCommand input;

        #endregion

        Establish establish = () =>
                                  {
                                      input = Pleasure.Generator.Invent<SignInUserCommand>();

                                      mockController = MockController<AccountController>
                                              .When();
                                  };

        Because of = () => { result = mockController.Original.SignIn(input); };

        It should_be_success = () => result.ShouldBeRedirectToAction<HomeController>(r => r.Index());

        It should_be_push = () => mockController.ShouldBePush(input);
    }
}