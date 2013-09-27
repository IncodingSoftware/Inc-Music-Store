namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AddGenreCommand))]
    public class When_add_genre
    {
        #region Estabilish value

        static MockMessage<AddGenreCommand, object> mockCommand;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<AddGenreCommand>();

                                      mockCommand = MockCommand<AddGenreCommand>
                                              .When(command);
                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_save = () => mockCommand.ShouldBeSave<Genre>(genre => genre.ShouldEqualWeak(mockCommand.Original, dsl => dsl.IgnoreBecauseNotUse(r => r.Albums)));
    }
}