namespace IncMusicStore.Domain
{
    public interface IFormAuthentication
    {
        void SignIn(string login, string id, bool persistence);

        void SignOut();

        bool IsAuthentication();
    }
}