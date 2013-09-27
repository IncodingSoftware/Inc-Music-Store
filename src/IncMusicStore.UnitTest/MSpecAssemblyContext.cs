namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Configuration;
    using System.Globalization;
    using System.Threading;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using IncMusicStore.Domain;
    using Incoding.Block.Caching;
    using Incoding.Block.IoC;
    using Incoding.MSpecContrib;
    using Machine.Specifications;
    using Machine.Specifications.Annotations;

    #endregion

    ////ncrunch: no coverage start
    [UsedImplicitly]
    public class MSpecAssemblyContext : IAssemblyContext
    {
        #region IAssemblyContext Members

        public void OnAssemblyStart()
        {
            var enCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = enCulture;
            Thread.CurrentThread.CurrentUICulture = enCulture;

            var configure = Fluently
                    .Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                                                .ConnectionString(ConfigurationManager.ConnectionStrings["IncMusicStoreTest"].ConnectionString)
                                                .ShowSql())
                    .Mappings(configuration => configuration.FluentMappings.AddFromAssemblyOf<Album>());

            NHibernatePleasure.StartSession(configure, true);
        }

        public void OnAssemblyComplete()
        {
            NHibernatePleasure.StopAllSession();
            CachingFactory.Instance.UnInitialize();
            IoCFactory.Instance.UnInitialize();
        }

        #endregion
    }

    ////ncrunch: no coverage end   
}