namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(Order))]
    public class When_save_Order : SpecWithPersistenceSpecification<Order>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.CreateDt, Pleasure.Generator.DateTime(), new DateSqlEqualityComparer())
                                   .CheckProperty(r => r.PromoCode, Pleasure.Generator.String())
                                   .CheckProperty(r => r.PaymentInfo, Pleasure.Generator.Invent<PaymentInfo>(), new WeakEqualityComparer())
                                   .CheckProperty(r => r.User, Pleasure.Generator.InventEntity<User>())
                                   .CheckList(r => r.Items, Pleasure.ToEnumerable(Pleasure.Generator.InventEntity<OrderItem>()), (order, item) => order.AddItem(item));

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}