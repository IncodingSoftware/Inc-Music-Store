namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Linq;
    using Incoding.CQRS;
    using Incoding.Extensions;

    #endregion

    public class GetAlbumQuery : QueryBase<Album>
    {
        #region Properties

        public string Id { get; set; }

        #endregion

        protected override Album ExecuteResult()
        {
            return Repository.Query(whereSpecification: new EntityByIdSpec<Album>(Id), 
                                    fetchSpecification: new AlbumWithGenreFetchSpec().And(new AlbumWithArtistFetchSpec()))
                             .First();
        }
    }
}