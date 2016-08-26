using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Domain.Mapping;
using NHibernate.Tool.hbm2ddl;

namespace Repository
{
    internal class SessionGenerator
    {
        #region Public static member

        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }

        #endregion


        #region Public member

        public ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        #endregion

        #region Non-public static member

        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();

        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(
                        builder =>
                            builder.Database("LearnEnglish")
                                .Server(@"MDDSK40035\SQLEXPRESS")
                                .TrustedConnection()))
                .Mappings(cfg => CreateMappings(cfg))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true));

            var conf = configuration.BuildConfiguration();

            return conf.BuildSessionFactory();
        }

        private static void CreateMappings(MappingConfiguration mappingConfiguration)
        {
            var assembly = typeof (WordMap).Assembly;

            mappingConfiguration.FluentMappings.AddFromAssembly(assembly);
            mappingConfiguration.HbmMappings.AddFromAssembly(assembly);
        }


        #endregion

        #region Non-public member

        private SessionGenerator()
        {
        }

        #endregion
    }
}
