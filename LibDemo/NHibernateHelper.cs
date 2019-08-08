using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
namespace LibDemo
{
    /// <summary>
    /// 用于创建会话工厂的类，设为密封类
    /// </summary>
    public sealed class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();

                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
