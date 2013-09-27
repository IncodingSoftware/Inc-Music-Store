namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(SignInUserCommand))]
    public class When_sign_in_user
    {
        #region Estabilish value

        static MockMessage<SignInUserCommand, object> mockCommand;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<SignInUserCommand>();
                                      var expected = Pleasure.Generator.Invent<User>();

                                      mockCommand = MockCommand<SignInUserCommand>
                                              .When(command)
                                              .StubQuery(whereSpecification: new UserByCredentialWhereSpec(command.Email, command.Password), 
                                                         entities: expected)
                                              .StubPublish<SingInUserEvent>(@event => @event.ShouldEqualWeak(expected, dsl => dsl.ForwardToValue(r => r.RememberMe, command.RememberMe)));
                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_published = () => mockCommand.ShouldBePublished();
    }
}