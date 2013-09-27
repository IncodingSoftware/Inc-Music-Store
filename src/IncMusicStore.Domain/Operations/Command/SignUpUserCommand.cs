namespace IncMusicStore.Domain
{
    #region << Using >>

    using Incoding.CQRS;

    #endregion

    public class SignUpUserCommand : CommandBase
    {
        #region Properties

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string First { get; set; }

        public string Middle { get; set; }

        public string Last { get; set; }

        #endregion

        public override void Execute()
        {
            var fullName = new FullName(First, Middle, Last);
            var user = new User(Email, Password, fullName);

            Repository.Save(user);
        }
    }
}