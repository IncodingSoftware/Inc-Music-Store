namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Diagnostics.CodeAnalysis;
    using Incoding.Data;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class Artist : IncEntityBase
    {
        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public Artist() { }

        public Artist(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties

        public virtual string Name { get; protected set; }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<Artist>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                Map(r => r.Name);
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}