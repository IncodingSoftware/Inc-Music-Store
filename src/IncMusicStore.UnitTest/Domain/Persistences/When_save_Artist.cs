namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(Artist))]
    public class When_save_Artist : SpecWithPersistenceSpecification<Artist>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.Name, Pleasure.Generator.String());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}