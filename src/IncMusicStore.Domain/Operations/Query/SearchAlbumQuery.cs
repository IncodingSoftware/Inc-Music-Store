namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using Incoding.CQRS;
    using Incoding.Extensions;

    #endregion

    public class SearchAlbumQuery : QueryBase<List<Album>>
    {
        #region Properties

        public string[] GenreIds { get; set; }

        public string[] ArtistIds { get; set; }

        public string Title { get; set; }

        #endregion

        protected override List<Album> ExecuteResult()
        {
            return Repository
                    .Query(whereSpecification: new AlbumContainsTitleOptWhereSpec(this.Title)
                                               .And(new AblumInArtistsOptWhereSpec(ArtistIds))
                                               .And(new AlbumInGenresOptWhereSpec(GenreIds)), 
                           fetchSpecification: new AlbumWithArtistFetchSpec()
                                               .And(new AlbumWithGenreFetchSpec()))
                    .ToList();
        }
    }
}