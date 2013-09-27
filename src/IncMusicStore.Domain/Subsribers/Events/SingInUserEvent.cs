namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Diagnostics.CodeAnalysis;
    using Incoding.EventBroker;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class SingInUserEvent : IEvent
    {
        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public SingInUserEvent() { }

        public SingInUserEvent(User user, bool rememberMe)
        {
            Id = user.Id.ToString();
            Email = user.Email;
            RememberMe = rememberMe;
        }

        #endregion

        #region Properties

        public string Email { get; private set; }

        public string Id { get; private set; }

        public bool RememberMe { get; private set; }

        #endregion
    }
}