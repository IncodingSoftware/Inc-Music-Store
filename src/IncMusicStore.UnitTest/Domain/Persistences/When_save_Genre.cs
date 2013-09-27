namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(Genre))]
    public class When_save_Genre : SpecWithPersistenceSpecification<Genre>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.Name, Pleasure.Generator.String())
                                   .CheckProperty(r => r.Description, Pleasure.Generator.String());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema(setting => setting.IgnoreBecauseCalculate(r => r.Albums));
    }
}