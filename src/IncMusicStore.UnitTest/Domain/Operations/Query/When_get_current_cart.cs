namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(GetCurrentCartQuery))]
    public class When_get_current_cart
    {
        #region Estabilish value

        static MockMessage<GetCurrentCartQuery, Cart> mockQuery;

        static Cart expected;

        #endregion

        Establish establish = () =>
                                  {
                                      var query = Pleasure.Generator.Invent<GetCurrentCartQuery>();
                                      expected = Pleasure.Generator.Invent<Cart>();

                                      mockQuery = MockQuery<GetCurrentCartQuery, Cart>
                                              .When(query)
                                              .StubQuery(whereSpecification: new CartByUserWhereSpec(IncMusicStorePleasure.TheUserId()), 
                                                         fetchSpecification: new CartWithItemFetchSpec(), 
                                                         entities: expected);
                                  };

        Because of = () => mockQuery.Original.Execute();

        It should_be_result = () => mockQuery.ShouldBeIsResult(expected);
    }
}