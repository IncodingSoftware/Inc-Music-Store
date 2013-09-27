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

    [Subject(typeof(UserByCredentialWhereSpec))]
    public class When_user_by_credential
    {
        #region Estabilish value

        static IQueryable<User> fakeCollection;

        static List<User> filterCollection;

        #endregion

        Establish establish = () =>
                                  {
                                      Func<string, string, User> createEntity = (email, password) => Pleasure.MockStrictAsObject<User>(mock =>
                                                                                                                                           {
                                                                                                                                               mock.SetupGet(r => r.Email).Returns(email);
                                                                                                                                               mock.SetupGet(r => r.Password).Returns(password);
                                                                                                                                           });

                                      var wrongEmail = createEntity(Pleasure.Generator.String(), Pleasure.Generator.TheSameString());
                                      var wrongPassword = createEntity(Pleasure.Generator.TheSameString(), Pleasure.Generator.String());
                                      var wrongAll = createEntity(Pleasure.Generator.String(), Pleasure.Generator.String());
                                      var exists = createEntity(Pleasure.Generator.TheSameString(), Pleasure.Generator.TheSameString());
                                      fakeCollection = Pleasure.ToQueryable(wrongEmail, wrongPassword, wrongAll, exists);
                                  };

        Because of = () =>
                         {
                             filterCollection = fakeCollection
                                     .Where(new UserByCredentialWhereSpec(Pleasure.Generator.TheSameString(), Pleasure.Generator.TheSameString()).IsSatisfiedBy())
                                     .ToList();
                         };

        It should_be_filter = () =>
                                  {
                                      filterCollection.Count.ShouldEqual(1);
                                      filterCollection[0].Should(user =>
                                                                     {
                                                                         user.Email.ShouldBeTheSameString();
                                                                         user.Password.ShouldBeTheSameString();
                                                                     });
                                  };
    }
}