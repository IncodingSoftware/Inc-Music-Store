namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(CartByUserWhereSpec))]
    public class When_cart_by_user
    {
        #region Estabilish value

        static IQueryable<Cart> fakeCollection;

        static List<Cart> filterCollection;

        #endregion

        Establish establish = () =>
                                  {
                                      Func<string, Cart> createEntity = (userId) => Pleasure.MockStrictAsObject<Cart>(mock => mock.SetupGet(r => r.User.Id).Returns(userId));

                                      fakeCollection = Pleasure.ToQueryable(createEntity(Pleasure.Generator.String()), createEntity(Pleasure.Generator.TheSameString()));
                                  };

        Because of = () =>
                         {
                             filterCollection = fakeCollection
                                     .Where(new CartByUserWhereSpec(Pleasure.Generator.TheSameString()).IsSatisfiedBy())
                                     .ToList();
                         };

        It should_be_filter = () =>
                                  {
                                      filterCollection.Count.ShouldEqual(1);
                                      filterCollection[0].User.Id.ShouldEqual(Pleasure.Generator.TheSameString());
                                  };
    }
}