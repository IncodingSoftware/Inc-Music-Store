namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(OrderItem))]
    public class When_save_OrderItem : SpecWithPersistenceSpecification<OrderItem>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.UnitPrice, Pleasure.Generator.PositiveDecimal())
                                   .CheckProperty(r => r.Quantity, Pleasure.Generator.PositiveNumber())
                                   .CheckReference(r => r.Album, Pleasure.Generator.InventEntity<Album>())
                                   .CheckReference(r => r.Order, Pleasure.Generator.InventEntity<Order>());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}