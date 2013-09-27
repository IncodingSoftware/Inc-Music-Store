namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Collections.Generic;
    using IncMusicStore.Domain;
    using Incoding.Data;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(GetAlbumsTopSellingQuery))]
    public class When_get_albums_top_selling
    {
        #region Estabilish value

        static MockMessage<GetAlbumsTopSellingQuery, List<Album>> mockQuery;

        static List<Album> expected;

        #endregion

        Establish establish = () =>
                                  {
                                      var query = Pleasure.Generator.Invent<GetAlbumsTopSellingQuery>();
                                      expected = Pleasure.ToList(Pleasure.Generator.Invent<Album>());

                                      mockQuery = MockQuery<GetAlbumsTopSellingQuery, List<Album>>
                                              .When(query)
                                              .StubPaginated(new PaginatedSpecification(1, 10), 
                                                             fetchSpecification: new AlbumWithOrderItemFetchSpec(), 
                                                             orderSpecification: new AlbumByOrderItemCountOrderSpec(), 
                                                             result: new IncPaginatedResult<Album>(expected, 1));
                                  };

        Because of = () => mockQuery.Original.Execute();

        It should_be_result = () => mockQuery.ShouldBeIsResult(expected);
    }
}