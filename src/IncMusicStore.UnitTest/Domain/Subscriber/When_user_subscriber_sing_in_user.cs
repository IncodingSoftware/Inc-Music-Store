namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;
    using Moq;
    using It = Machine.Specifications.It;

    #endregion

    [Subject(typeof(UserSubscriber))]
    public class When_user_subscriber_sing_in_user
    {
        #region Estabilish value

        static Mock<IFormAuthentication> formAuthentication;

        static UserSubscriber subscriber;

        static SingInUserEvent currentEvent;

        #endregion

        Establish establish = () =>
                                  {
                                      currentEvent = Pleasure.Generator.Invent<SingInUserEvent>();
                                      formAuthentication = Pleasure.Mock<IFormAuthentication>();

                                      subscriber = new UserSubscriber(formAuthentication.Object);
                                  };

        Because of = () => subscriber.Subscribe(currentEvent);

        It should_be_sign_in = () => formAuthentication.Verify(r => r.SignIn(currentEvent.Email, currentEvent.Id, currentEvent.RememberMe));
    }
}