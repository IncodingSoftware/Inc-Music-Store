namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(CartItem))]
    public class When_save_CartItem : SpecWithPersistenceSpecification<CartItem>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.Quantity, Pleasure.Generator.PositiveNumber())
                                   .CheckReference(r => r.Album, Pleasure.Generator.InventEntity<Album>())                                   
                                   .CheckReference(r => r.Cart, Pleasure.Generator.InventEntity<Cart>());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}