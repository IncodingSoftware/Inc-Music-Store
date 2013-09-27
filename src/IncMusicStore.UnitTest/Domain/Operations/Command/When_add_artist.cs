namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AddArtistCommand))]
    public class When_add_artist
    {
        #region Estabilish value

        static MockMessage<AddArtistCommand, object> mockCommand;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<AddArtistCommand>();

                                      mockCommand = MockCommand<AddArtistCommand>
                                              .When(command);
                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_save = () => mockCommand.ShouldBeSave<Artist>(artist => artist.ShouldEqualWeak(mockCommand.Original));
    }
}