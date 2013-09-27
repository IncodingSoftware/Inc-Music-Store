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

    [Subject(typeof(ArtistController))]
    public class When_artist_controller_fetch_for_dd
    {
        #region Estabilish value

        static MockController<ArtistController> mockController;

        static ActionResult result;

        static List<Artist> expected;

        #endregion

        Establish establish = () =>
                                  {
                                      var query = Pleasure.Generator.Invent<GetEntitiesQuery<Artist>>();
                                      expected = Pleasure.ToList(Pleasure.Generator.Invent<Artist>());

                                      mockController = MockController<ArtistController>
                                              .When()
                                              .StubQuery(query, expected);
                                  };

        Because of = () => { result = mockController.Original.FetchForDD(); };

        It should_be_result = () => result.ShouldBeIncodingData<List<KeyValueVm>>(vms => vms.ShouldEqualWeakEach(expected, (dsl, i) => dsl.Forward(r => r.Value, r => r.Id)
                                                                                                                                          .Forward(r => r.Text, r => r.Name)
                                                                                                                                          .IgnoreBecauseNotUse(r => r.Title)
                                                                                                                                          .IgnoreBecauseNotUse(r => r.Selected)));
    }
}