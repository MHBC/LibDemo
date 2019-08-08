using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibDemo;
using LibDemo.Domain;
using NHibernate;
using NHibernate.Cfg;
using LibDemo.Manager;

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
        public void Initialization()
        {
            DataCRUD.Create<Department>(new Department()
            {
                DepartmentName = "管理",
            });
            DataCRUD.Create<Department>(new Department()
            {
                DepartmentName = "技术",
            });
            DataCRUD.Create<Department>(new Department()
            {
                DepartmentName = "市场",
            });
            DataCRUD.Create<Department>(new Department()
            {
                DepartmentName = "后勤",
            });
            DataCRUD.Create<Community>(new Community()
            {
                CommunityName = "工会",
            });
            DataCRUD.Create<Admin>(new Admin()
            {
                Account="Admin",
                Password="Admin",
                FamilyName="Admin",
                FirstName="Admin",
                JobTitle="Admin",
                AdminAccount="admin",
                AdminPassword="123456"
            });
        }
    }
}
