namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(Album))]
    public class When_save_Album : SpecWithPersistenceSpecification<Album>
    {
        Because of = () => persistenceSpecification
                                   .CheckReference(r => r.Genre, Pleasure.Generator.InventEntity<Genre>())
                                   .CheckReference(r => r.Artist, Pleasure.Generator.InventEntity<Artist>())
                                   .CheckProperty(r => r.ArtUrl, Pleasure.Generator.String())
                                   .CheckProperty(r => r.Price, Pleasure.Generator.PositiveDecimal())
                                   .CheckProperty(r => r.Title, Pleasure.Generator.String());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema(setting => setting.IgnoreBecauseCalculate(r => r.OrderItems));
    }
}