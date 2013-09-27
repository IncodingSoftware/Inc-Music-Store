namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(User))]
    public class When_save_User : SpecWithPersistenceSpecification<User>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.Email, Pleasure.Generator.String())
                                   .CheckProperty(r => r.Password, Pleasure.Generator.String())
                                   .CheckReference(r => r.Cart, Pleasure.Generator.InventEntity<Cart>())
                                   .CheckList(r => r.Orders, Pleasure.ToEnumerable(Pleasure.Generator.InventEntity<Order>()), (user, order) => user.AddOrder(order))
                                   .CheckProperty(r => r.Name, Pleasure.Generator.Invent<FullName>(), new WeakEqualityComparer());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}