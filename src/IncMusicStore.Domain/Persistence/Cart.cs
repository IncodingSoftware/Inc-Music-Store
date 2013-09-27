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

    public class Cart : IncEntityBase
    {
        #region Fields

        readonly IList<CartItem> items = new List<CartItem>();

        #endregion

        #region Properties

        public virtual User User { get; protected set; }

        public virtual ReadOnlyCollection<CartItem> Items
        {
            get { return new ReadOnlyCollection<CartItem>(this.items); }
        }

        #endregion

        #region Api Methods

        public virtual void AddItem(CartItem item)
        {
            item.Cart = this;
            this.items.Add(item);
        }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<Cart>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                References(r => r.User).Cascade.SaveUpdate();
                HasMany(r => r.Items).Access.CamelCaseField().Cascade.AllDeleteOrphan();
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}