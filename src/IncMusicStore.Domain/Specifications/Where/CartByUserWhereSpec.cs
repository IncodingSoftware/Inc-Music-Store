namespace IncMusicStore.Domain
{
    using System;
    using System.Linq.Expressions;
    using Incoding;

    public class CartByUserWhereSpec : Specification<Cart>
    {
        #region Fields

        readonly string userId;

        #endregion

        #region Constructors

        public CartByUserWhereSpec(string userId)
        {
            this.userId = userId;
        }

        #endregion

        public override Expression<Func<Cart, bool>> IsSatisfiedBy()
        {
            return r => r.User.Id == this.userId;
        }
    }
}