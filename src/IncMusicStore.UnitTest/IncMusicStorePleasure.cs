namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.Block.IoC;
    using Incoding.MSpecContrib;

    #endregion

    public static class IncMusicStorePleasure
    {
        #region Factory constructors

        public static string TheUserId()
        {
            const string userid = "userId";
            var sessionContext = Pleasure.MockStrictAsObject<ISessionContext>(mock => mock.SetupGet(r => r.UserId).Returns(userid));
            IoCFactory.Instance.StubTryResolve(sessionContext);
            return userid;
        }

        #endregion
    }
}