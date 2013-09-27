namespace IncMusicStore.Domain
{
    #region << Using >>

    using Incoding.Block.IoC;

    #endregion

    public static class IncMusicStoreApplication
    {
        #region Properties

        public static string UserId
        {
            get { return IoCFactory.Instance.TryResolve<ISessionContext>().UserId; }
        }

        #endregion
    }
}