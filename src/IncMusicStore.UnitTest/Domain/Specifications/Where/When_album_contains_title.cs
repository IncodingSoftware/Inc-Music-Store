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

    [Subject(typeof(AlbumContainsTitleOptWhereSpec))]
    public class When_album_contains_title
    {
        #region Estabilish value

        static IQueryable<Album> fakeCollection;

        static List<Album> filterCollection;

        #endregion

        Establish establish = () =>
                                  {
                                      Func<string, Album> createEntity = (title) => Pleasure.MockStrictAsObject<Album>(mock => mock.SetupGet(r => r.Title).Returns(title));

                                      fakeCollection = Pleasure.ToQueryable(createEntity(Pleasure.Generator.String()), createEntity(Pleasure.Generator.TheSameString()));
                                  };

        Because of = () =>
                         {
                             filterCollection = fakeCollection
                                     .Where(new AlbumContainsTitleOptWhereSpec(Pleasure.Generator.TheSameString()).IsSatisfiedBy())
                                     .ToList();
                         };

        It should_be_filter = () =>
                                  {
                                      filterCollection.Count.ShouldEqual(1);
                                      filterCollection[0].Title.ShouldBeTheSameString();
                                  };

        It should_be_optional = () => fakeCollection
                                              .Count(new AlbumContainsTitleOptWhereSpec(string.Empty).IsSatisfiedBy())
                                              .ShouldEqual(2);
    }
}