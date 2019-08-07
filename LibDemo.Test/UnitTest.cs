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
