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

    public class AlbumInGenresOptWhereSpec : Specification<Album>
    {
        #region Fields

        readonly List<object> genreIds;

        #endregion

        #region Constructors

        public AlbumInGenresOptWhereSpec(string[] genreIds)
        {
            this.genreIds = genreIds.ReturnOrDefault(r => r.OfType<object>().ToList(), null);
        }

        #endregion

        public override Expression<Func<Album, bool>> IsSatisfiedBy()
        {
            if (this.genreIds == null)
                return r => true;

            return r => this.genreIds.Contains(r.Genre.Id);
        }
    }
}