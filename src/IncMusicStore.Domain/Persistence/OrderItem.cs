namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Diagnostics.CodeAnalysis;
    using Incoding.Data;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class OrderItem : IncEntityBase
    {
        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public OrderItem() { }

        public OrderItem(CartItem cartItem)
        {
            Quantity = cartItem.Quantity;
            Album = cartItem.Album;
            UnitPrice = cartItem.Album.Price;
        }

        #endregion

        #region Properties

        public virtual Order Order { get; protected internal set; }

        public virtual int Quantity { get; protected set; }

        public virtual decimal UnitPrice { get; protected set; }

        public virtual Album Album { get; protected set; }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<OrderItem>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                Map(r => r.Quantity);
                Map(r => r.UnitPrice);
                References(r => r.Album).Cascade.SaveUpdate();
                References(r => r.Order).Cascade.SaveUpdate();
            }

            #endregion

            ////ncrunch: no coverage end        
        }

        #endregion
    }
}