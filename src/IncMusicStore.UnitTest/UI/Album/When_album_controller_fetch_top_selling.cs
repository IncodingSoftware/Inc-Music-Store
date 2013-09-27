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

    [Subject(typeof(AlbumController))]
    public class When_album_controller_fetch_top_selling
    {
        #region Estabilish value

        static MockController<AlbumController> mockController;

        static ActionResult result;

        static List<Album> expected;

        #endregion

        Establish establish = () =>
                                  {
                                      var query = Pleasure.Generator.Invent<GetAlbumsTopSellingQuery>();
                                      expected = Pleasure.ToList(Pleasure.Generator.Invent<Album>(dsl => dsl.Tuning(r => r.Id, Pleasure.Generator.String())));

                                      mockController = MockController<AlbumController>
                                              .When()
                                              .StubQuery(query, expected);
                                  };

        Because of = () => { result = mockController.Original.FetchTopSelling(); };

        It should_be_result = () => result.ShouldBeIncodingData<List<AlbumTopSellingVm>>(vms => vms.ShouldEqualWeakEach(expected));
    }
}