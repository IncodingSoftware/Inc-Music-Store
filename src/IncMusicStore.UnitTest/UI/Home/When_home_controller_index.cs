namespace IncMusicStore.UnitTest.Home
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.UI.Controllers;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(HomeController))]
    public class When_home_controller_index
    {
        #region Estabilish value

        static MockController<HomeController> mockController;

        static ActionResult result;

        #endregion

        Establish establish = () =>
                                  {
                                      mockController = MockController<HomeController>
                                              .When();
                                  };

        Because of = () => { result = mockController.Original.Index(); };

        It should_be_result = () => result.ShouldBeOfType<ViewResult>();
    }
}