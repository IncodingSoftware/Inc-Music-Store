namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Linq;
    using Incoding;
    using Incoding.CQRS;

    #endregion

    public class SignInUserCommand : CommandBase
    {
        #region Properties

        public string Password { get; set; }

        public string Email { get; set; }

        public bool RememberMe { get; set; }

        #endregion

        public override void Execute()
        {
            var user = Repository
                    .Query(whereSpecification: new UserByCredentialWhereSpec(Email, Password))
                    .FirstOrDefault();

            if (user == null)
                throw IncWebException.ForServer("Please use correct email and password");

            EventBroker.Publish(new SingInUserEvent(user, RememberMe));
        }
    }
}