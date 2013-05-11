using System.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using WebDriveApi.Domain;
using Configuration = NHibernate.Cfg.Configuration;

namespace WebDriveApi.Helpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var autoMap = AutoMap.AssemblyOf<DomainEntity>().Where(t => typeof (DomainEntity).IsAssignableFrom(t));

                    _sessionFactory = Fluently.Configure()
                                              .Database(
                                                  MsSqlConfiguration.MsSql2008.ConnectionString(
                                                      ConfigurationManager.ConnectionStrings["context"].ConnectionString))
                                              .Mappings(m => m.AutoMappings.Add(autoMap))
                                              .ExposeConfiguration(TreatConfiguration)
                                              .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static void TreatConfiguration(Configuration configuration)
        {
            var update = new SchemaUpdate(configuration);
            update.Execute(false, true);
        }
    }
}