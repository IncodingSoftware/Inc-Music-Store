namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;
    using IncMusicStore.UI.Models;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AlbumController))]
    public class When_album_controller_details
    {
        #region Estabilish value

        static MockController<AlbumController> mockController;

        static ActionResult result;

        static GetAlbumQuery query;

        static Album expected;

        #endregion

        Establish establish = () =>
                                  {
                                      query = Pleasure.Generator.Invent<GetAlbumQuery>();
                                      expected = Pleasure.Generator.Invent<Album>(dsl => dsl
                                                                                                 .Tuning(r => r.Price, (decimal)124.23)
                                                                                                 .GenerateTo<Genre>(r => r.Genre)
                                                                                                 .GenerateTo<Artist>(r => r.Artist));

                                      mockController = MockController<AlbumController>
                                              .When()
                                              .StubQuery(query, expected);
                                  };

        Because of = () => { result = mockController.Original.Details(query); };

        It should_be_success = () => result.ShouldBeIncodingSuccess();

        It should_be_render_model = () => mockController.ShouldBeRenderModel<AlbumDetailsVm>(vm => vm.ShouldEqualWeak(expected, dsl => dsl.ForwardToValue(r => r.Artist, expected.Artist.Name)
                                                                                                                                          .ForwardToValue(r => r.Genre, expected.Genre.Name)
                                                                                                                                          .ForwardToValue(r => r.Price, "$124.23")));
    }
}