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
                    Name = "ChiangKaiShek",
                    Sex = 'F',
                    Job = "Doctor"
                };
                session.Save(princess);
                tx.Commit();
            }
        }
    }
}
