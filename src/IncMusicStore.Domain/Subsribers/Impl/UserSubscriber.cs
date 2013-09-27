namespace IncMusicStore.Domain
{
    #region << Using >>

    using Incoding.EventBroker;

    #endregion

    public class UserSubscriber : IEventSubscriber<SingInUserEvent>
    {
        #region Fields

        readonly IFormAuthentication formAuthentication;

        #endregion

        #region Constructors

        public UserSubscriber(IFormAuthentication formAuthentication)
        {
            this.formAuthentication = formAuthentication;
        }

        #endregion

        #region IEventSubscriber<SingInUserEvent> Members

        public void Subscribe(SingInUserEvent @event)
        {
            this.formAuthentication.SignIn(@event.Email, @event.Id, @event.RememberMe);
        }

        #endregion

        ////ncrunch: no coverage start
        #region Disposable

        public void Dispose() { }

        #endregion

        ////ncrunch: no coverage end
    }
}