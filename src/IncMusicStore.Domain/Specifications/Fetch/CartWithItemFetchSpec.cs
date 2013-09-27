namespace IncMusicStore.Domain
{
    using System;
    using Incoding.Data;

    public class CartWithItemFetchSpec : FetchSpecification<Cart>
    {
        public override Action<AdHocFetchSpecification<Cart>> FetchedBy()
        {
            return specification => specification.Join(r => r.Items).JoinMany(r => r.Items, r => r.Album);
        }
    }
}