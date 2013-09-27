namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.CQRS;
    using Incoding.Extensions;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(GetAlbumQuery))]
    public class When_get_album
    {
        #region Estabilish value

        static MockMessage<GetAlbumQuery, Album> mockQuery;

        static Album expected;

        #endregion

        Establish establish = () =>
                                  {
                                      var query = Pleasure.Generator.Invent<GetAlbumQuery>();
                                      expected = Pleasure.Generator.Invent<Album>();

                                      mockQuery = MockQuery<GetAlbumQuery, Album>
                                              .When(query)
                                              .StubQuery(whereSpecification: new EntityByIdSpec<Album>(query.Id), 
                                                         fetchSpecification: new AlbumWithGenreFetchSpec().And(new AlbumWithArtistFetchSpec()), 
                                                         entities: expected);
                                  };

        Because of = () => mockQuery.Original.Execute();

        It should_be_result = () => mockQuery.ShouldBeIsResult(expected);
    }
}