namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Linq;
    using Incoding.Data;

    #endregion

    public class AlbumByOrderItemCountOrderSpec : OrderSpecification<Album>
    {
        public override Action<AdHocOrderSpecification<Album>> SortedBy()
        {
            return specification => specification.OrderBy(r => r.OrderItems.Count());
        }
    }
}