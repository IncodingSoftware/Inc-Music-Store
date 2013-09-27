namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Linq;
    using Incoding.CQRS;

    #endregion

    public class GetCurrentCartQuery : QueryBase<Cart>
    {
        protected override Cart ExecuteResult()
        {
            return Repository.Query(whereSpecification: new CartByUserWhereSpec(IncMusicStoreApplication.UserId), 
                                    fetchSpecification: new CartWithItemFetchSpec())
                             .First();
        }
    }
}