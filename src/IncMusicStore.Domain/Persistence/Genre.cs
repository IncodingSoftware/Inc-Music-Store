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

    public class Genre : IncEntityBase
    {
        #region Fields

        readonly IList<Album> albums = new List<Album>();

        #endregion

        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public Genre() { }

        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion

        #region Properties

        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual IReadOnlyCollection<Album> Albums
        {
            get { return new ReadOnlyCollection<Album>(this.albums); }
        }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<Genre>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                Map(r => r.Name);
                Map(r => r.Description).Length(1000);
                HasMany(r => r.Albums).Access.CamelCaseField().Cascade.AllDeleteOrphan();
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}