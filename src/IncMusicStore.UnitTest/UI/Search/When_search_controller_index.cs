namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.UI.Controllers;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(SearchController))]
    public class When_search_controller_index
    {
        #region Estabilish value

        static MockController<SearchController> mockController;

        static ActionResult result;

        #endregion

        Establish establish = () =>
                                  {
                                      mockController = MockController<SearchController>
                                              .When();
                                  };

        Because of = () => { result = mockController.Original.Index(); };

        It should_be_result = () => result.ShouldBeOfType<ViewResult>();
    }
}