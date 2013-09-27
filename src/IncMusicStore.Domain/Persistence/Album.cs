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

    public class Album : IncEntityBase
    {
        #region Fields

        readonly IList<OrderItem> orderItems = new List<OrderItem>();

        #endregion

        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public Album() { }

        public Album(string title, Artist artist, Genre genre, decimal price, string artUrl)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Price = price;
            ArtUrl = artUrl;
        }

        #endregion

        #region Properties

        public virtual Genre Genre { get; protected set; }

        public virtual Artist Artist { get; protected set; }

        public virtual string Title { get; protected set; }

        public virtual decimal Price { get; protected set; }

        public virtual string ArtUrl { get; protected set; }

        public virtual IReadOnlyCollection<OrderItem> OrderItems
        {
            get { return new ReadOnlyCollection<OrderItem>(this.orderItems); }
        }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<Album>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                References(r => r.Genre).Cascade.SaveUpdate();
                References(r => r.Artist).Cascade.SaveUpdate();
                Map(r => r.Title);
                Map(r => r.Price);
                Map(r => r.ArtUrl);
                HasMany(r => r.OrderItems).Access.CamelCaseField();
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}