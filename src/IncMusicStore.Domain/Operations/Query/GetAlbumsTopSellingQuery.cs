namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Collections.Generic;
    using Incoding.CQRS;
    using Incoding.Data;

    #endregion

    public class GetAlbumsTopSellingQuery : QueryBase<List<Album>>
    {
        protected override List<Album> ExecuteResult()
        {
            return Repository
                    .Paginated(paginatedSpecification: new PaginatedSpecification(1, 10), 
                               fetchSpecification: new AlbumWithOrderItemFetchSpec(), 
                               orderSpecification: new AlbumByOrderItemCountOrderSpec())
                    .Items;
        }
    }
}