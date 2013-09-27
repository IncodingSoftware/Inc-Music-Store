namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(SignUpUserCommand))]
    public class When_sign_up_user
    {
        #region Estabilish value

        static MockMessage<SignUpUserCommand, object> mockCommand;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<SignUpUserCommand>();

                                      mockCommand = MockCommand<SignUpUserCommand>
                                              .When(command);
                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_save = () =>
                            mockCommand.ShouldBeSave<User>(user => user.ShouldEqualWeak(mockCommand.Original, dsl => dsl.IgnoreBecauseNotUse(r => r.Orders)
                                                                                                                        .ForwardToAction(r => r.Cart, s => s.Cart.ShouldNotBeNull())
                                                                                                                        .ForwardToAction(r => r.Name, s => s.Name.ShouldEqualWeak(mockCommand.Original))));
    }
}