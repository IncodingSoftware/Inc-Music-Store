namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using IncMusicStore.UI.Models;
    using Incoding.CQRS;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(GenreController))]
    public class When_genre_controller_fetch
    {
        #region Estabilish value

        static MockController<GenreController> mockController;

        static ActionResult result;

        static List<Genre> expected;

        #endregion

        Establish establish = () =>
                                  {
                                      expected = Pleasure.ToList(Pleasure.Generator.Invent<Genre>());

                                      mockController = MockController<GenreController>
                                              .When()
                                              .StubQuery(new GetEntitiesQuery<Genre>(), expected);
                                  };

        Because of = () => { result = mockController.Original.Fetch(); };

        It should_be_result = () => result.ShouldBeIncodingData<List<GenreVm>>(vms => vms.ShouldEqualWeakEach(expected));
    }
}