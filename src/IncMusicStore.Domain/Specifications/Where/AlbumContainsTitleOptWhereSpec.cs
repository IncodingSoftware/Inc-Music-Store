namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Linq.Expressions;
    using Incoding;

    #endregion

    public class AlbumContainsTitleOptWhereSpec : Specification<Album>
    {
        #region Fields

        readonly string title;

        #endregion

        #region Constructors

        public AlbumContainsTitleOptWhereSpec(string title)
        {
            this.title = title;
        }

        #endregion

        public override Expression<Func<Album, bool>> IsSatisfiedBy()
        {
            if (string.IsNullOrWhiteSpace(this.title))
                return r => true;

            return r => r.Title.Contains(this.title);
        }
    }
}