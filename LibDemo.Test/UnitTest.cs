using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibDemo;
using LibDemo.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace LibDemo.Test
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Method for building a new database automatically
        /// No need to run if one with test data already exists
        /// </summary>
        [TestMethod]
        public void BuildTest()
        {
            // Open a new sessionfactory with specialized configuration
            // to create a new database. Name and path are set in hibernate.cfg.xml
            var config = new Configuration();
            config.DataBaseIntegration(db =>
            {
                db.SchemaAction = SchemaAutoAction.Create;
            });
            config.Configure();
            ISessionFactory sessionFactory = config.BuildSessionFactory();
            sessionFactory.Close();
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            ISession session = NHibernateHelper.GetSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                var princess = new Person()
                {
                    
                };
                session.Save(princess);
                tx.Commit();
            }
        }
    }
}
