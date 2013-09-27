namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Incoding;
    using Incoding.Maybe;

    #endregion

    public class AblumInArtistsOptWhereSpec : Specification<Album>
    {
        #region Fields

        readonly List<object> artistIds;

        #endregion

        #region Constructors

        public AblumInArtistsOptWhereSpec(string[] artistIds)
        {
            this.artistIds = artistIds.ReturnOrDefault(r => r.OfType<object>().ToList(),null);
        }

        #endregion

        public override Expression<Func<Album, bool>> IsSatisfiedBy()
        {
            if (this.artistIds == null)
                return r => true;

            return r => this.artistIds.Contains(r.Artist.Id);
        }
    }
}