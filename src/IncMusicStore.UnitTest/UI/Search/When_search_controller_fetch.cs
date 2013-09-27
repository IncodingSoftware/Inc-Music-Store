namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using IncMusicStore.UI.Models;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(SearchController))]
    public class When_search_controller_fetch
    {
        #region Estabilish value

        static MockController<SearchController> mockController;

        static ActionResult result;

        static List<Album> expected;

        static SearchAlbumQuery query;

        #endregion

        Establish establish = () =>
                                  {
                                      query = Pleasure.Generator.Invent<SearchAlbumQuery>();
                                      expected = Pleasure.ToList(Pleasure.Generator.Invent<Album>(dsl => dsl.GenerateTo<Genre>(r => r.Genre)
                                                                                                            .GenerateTo<Artist>(r => r.Artist)));

                                      mockController = MockController<SearchController>
                                              .When()
                                              .StubQuery(query, expected);
                                  };

        Because of = () => { result = mockController.Original.Fetch(query); };

        It should_be_result = () => result.ShouldBeIncodingData<List<AlbumDetailsVm>>(vms => vms.ShouldEqualWeakEach(vms));
    }
}