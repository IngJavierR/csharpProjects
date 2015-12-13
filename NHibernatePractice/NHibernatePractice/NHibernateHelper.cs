using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernatePractice
{
    public sealed class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static void OpenSession()
        {
            Configuration configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(Assembly.GetCallingAssembly());
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession GetCurrentESession()
        {
            if (_sessionFactory == null)
            {
                OpenSession();
            }
            return _sessionFactory.OpenSession();
        }

        public static void CloseSessionFactory()
        {
            if(_sessionFactory != null)
                _sessionFactory.Close();
        }
    }
}
