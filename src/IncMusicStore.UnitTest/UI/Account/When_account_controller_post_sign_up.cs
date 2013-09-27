namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AccountController))]
    public class When_account_controller_post_sign_up
    {
        #region Estabilish value

        static MockController<AccountController> mockController;

        static SignUpUserCommand input;

        #endregion

        Establish establish = () =>
                                  {
                                      input = Pleasure.Generator.Invent<SignUpUserCommand>();

                                      mockController = MockController<AccountController>
                                              .When();
                                  };

        Because of = () => mockController.Original.SignUp(input);

        It should_be_push = () => mockController.ShouldBePush(input);
    }
}