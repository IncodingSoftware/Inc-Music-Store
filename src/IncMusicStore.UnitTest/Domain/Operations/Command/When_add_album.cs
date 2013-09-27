namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AddAlbumCommand))]
    public class When_add_album
    {
        #region Estabilish value

        static MockMessage<AddAlbumCommand, object> mockCommand;

        static Artist artist;

        static Genre genre;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<AddAlbumCommand>();

                                      artist = Pleasure.Generator.Invent<Artist>();
                                      genre = Pleasure.Generator.Invent<Genre>();

                                      mockCommand = MockCommand<AddAlbumCommand>
                                              .When(command)
                                              .StubGetById(command.ArtistId, artist)
                                              .StubGetById(command.GenreId, genre);
                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_save = () => mockCommand.ShouldBeSave<Album>(album => album.ShouldEqualWeak(mockCommand.Original, dsl => dsl.IgnoreBecauseNotUse(r => r.OrderItems)
                                                                                                                                 .ForwardToValue(r => r.Artist, artist)
                                                                                                                                 .ForwardToValue(r => r.Genre, genre)));
    }
}