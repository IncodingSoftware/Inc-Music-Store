namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Diagnostics.CodeAnalysis;
    using Incoding.Data;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class CartItem : IncEntityBase
    {
        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public CartItem() { }

        public CartItem(Album album, int quantity)
        {
            Album = album;
            Quantity = quantity;
        }

        #endregion

        #region Properties

        public virtual Album Album { get; protected set; }

        public virtual int Quantity { get; protected set; }

        public virtual Cart Cart { get; protected internal set; }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<CartItem>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                Map(r => r.Quantity);
                References(r => r.Cart).Cascade.SaveUpdate();
                References(r => r.Album).Cascade.SaveUpdate();
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}