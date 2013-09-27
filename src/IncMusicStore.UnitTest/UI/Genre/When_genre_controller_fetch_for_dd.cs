namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using Incoding.CQRS;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(GenreController))]
    public class When_genre_controller_fetch_for_dd
    {
        #region Estabilish value

        static MockController<GenreController> mockController;

        static ActionResult result;

        static List<Genre> expected;

        #endregion

        Establish establish = () =>
                                  {
                                      var query = Pleasure.Generator.Invent<GetEntitiesQuery<Genre>>();
                                      expected = Pleasure.ToList(Pleasure.Generator.Invent<Genre>());

                                      mockController = MockController<GenreController>
                                              .When()
                                              .StubQuery(query, expected);
                                  };

        Because of = () => { result = mockController.Original.FetchForDD(); };

        It should_be_result = () => result.ShouldBeIncodingData<List<KeyValueVm>>(vms => vms.ShouldEqualWeakEach(expected, (dsl, i) => dsl.Forward(r => r.Value, r => r.Id)
                                                                                                                                          .Forward(r => r.Text, r => r.Name)
                                                                                                                                          .IgnoreBecauseNotUse(r => r.Title)
                                                                                                                                          .IgnoreBecauseNotUse(actualIgnore: r => r.Selected)));
    }
}