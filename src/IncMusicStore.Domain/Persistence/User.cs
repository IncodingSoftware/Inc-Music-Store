namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Incoding.Data;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class User : IncEntityBase
    {
        #region Fields

        readonly IList<Order> orders = new List<Order>();

        #endregion

        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public User() { }

        public User(string email, string password, FullName fullName)
        {
            Email = email;
            Password = password;
            Name = fullName;
            Cart = new Cart();
        }

        #endregion

        #region Properties

        public virtual FullName Name { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual string Password { get; protected set; }

        public virtual Cart Cart { get; protected set; }

        public virtual ReadOnlyCollection<Order> Orders
        {
            get { return new ReadOnlyCollection<Order>(this.orders); }
        }

        #endregion

        #region Api Methods

        public virtual void AddOrder(Order order)
        {
            order.User = this;
            this.orders.Add(order);
        }

        public virtual void NewCart()
        {
            Cart = new Cart();
        }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<User>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                Map(r => r.Email);
                Component(r => r.Name, part =>
                                           {
                                               part.Map(r => r.First);
                                               part.Map(r => r.Last);
                                               part.Map(r => r.Middle);
                                           });
                Map(r => r.Password);
                References(r => r.Cart).Cascade.All();
                HasMany(r => r.Orders).Access.CamelCaseField().Cascade.AllDeleteOrphan();
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}