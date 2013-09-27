namespace IncMusicStore.UI
{
    #region << Using >>

    using System.Configuration;
    using System.Linq;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using IncMusicStore.Domain;
    using Incoding.Block.IoC;
    using Incoding.Block.Logging;
    using Incoding.CQRS;
    using Incoding.Data;
    using Incoding.EventBroker;
    using NHibernate.Context;

    #endregion

    ////ncrunch: no coverage start
    public static class IncMusicStoreBootstrapped
    {
        #region Factory constructors

        public static void Start()
        {
            
            IoCFactory.Instance.Initialize(init => init.WithProvider(new StructureMapIoCProvider(registry =>
                                                                                                     {
                                                                                                         registry.For<IDispatcher>().Use<DefaultDispatcher>();
                                                                                                         registry.For<IEventBroker>().Use<DefaultEventBroker>();

                                                                                                         registry.For<ISessionContext>().Use<HttpSessionContext>();
                                                                                                         registry.For<IFormAuthentication>().Use<DefaultFormAuthentication>();

                                                                                                         var configure = Fluently
                                                                                                                 .Configure()
                                                                                                                 .Database(MsSqlConfiguration.MsSql2008
                                                                                                                                             .ConnectionString(ConfigurationManager.ConnectionStrings["IncMusicStore"].ConnectionString))
                                                                                                                 .Mappings(configuration => configuration.FluentMappings.AddFromAssembly(typeof(IncMusicStoreMap<>).Assembly))
                                                                                                                 .CurrentSessionContext<ThreadStaticSessionContext>();

                                                                                                         registry.For<IManagerDataBase>().Use(new NhibernateManagerDataBase(configure));
                                                                                                         registry.For<INhibernateSessionFactory>().Singleton().Use(() => new NhibernateSessionFactory(configure));

                                                                                                         registry.For<IUnitOfWorkFactory>().Use<NhibernateUnitOfWorkFactory>();
                                                                                                         registry.For<IUnitOfWork>().Use<NhibernateUnitOfWork>();
                                                                                                         registry.For<IRepository>().Use<NhibernateRepository>();

                                                                                                         registry.Scan(r =>
                                                                                                                           {
                                                                                                                               r.Assembly(typeof(DataBaseSetUp).Assembly);
                                                                                                                               r.AddAllTypesOf<ISetUp>();
                                                                                                                           });
                                                                                                     })));

            foreach (var setUp in IoCFactory.Instance.ResolveAll<ISetUp>().OrderBy(r => r.GetOrder()))
                setUp.Execute();
        }

        #endregion
    }

    ////ncrunch: no coverage end
}