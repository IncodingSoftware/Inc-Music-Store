namespace IncMusicStore.Domain
{
    using System;
    using System.Linq.Expressions;
    using Incoding;

    public class UserByCredentialWhereSpec : Specification<User>
    {
        #region Fields

        readonly string email;

        readonly string password;

        #endregion

        #region Constructors

        public UserByCredentialWhereSpec(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        #endregion

        public override Expression<Func<User, bool>> IsSatisfiedBy()
        {
            return r => r.Email == this.email && r.Password == this.password;
        }
    }
}