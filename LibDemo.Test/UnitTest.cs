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
            DataCRUD.Create<Admin>(new Admin()
            {
                Account = "Admin",
                Password = "Admin",
                FamilyName = "Admin",
                FirstName = "Admin",
                JobTitle = "Admin",
                AdminAccount = "admin",
                AdminPassword = "123456"
            });
            var person1 = new Person()
            {
                Account = "Account1",
                Password = "Password1",
                FamilyName = "张",
                FirstName = "三",
                JobTitle = "员工",
            };
            var person2 = new Person()
            {
                Account = "Account2",
                Password = "Password2",
                FamilyName = "李",
                FirstName = "四",
                JobTitle = "员工",
            };
            var person3 = new Person()
            {
                Account = "Account3",
                Password = "Password3",
                FamilyName = "王",
                FirstName = "五",
                JobTitle = "员工",
            };
            var depart1 = new Department()
            {
                DepartmentName = "管理"
            };
            var depart2 = new Department()
            {
                DepartmentName = "技术"
            };
            var depart3 = new Department()
            {
                DepartmentName = "市场"
            };
            var depart4 = new Department()
            {
                DepartmentName = "后勤"
            };
            var community1 = new Community()
            {
                CommunityName = "工会"
            };
            DataCRUD.Create<Person>(person1);
            DataCRUD.Create<Person>(person2);
            DataCRUD.Create<Person>(person3);
            DataCRUD.Create<Department>(depart1);
            DataCRUD.Create<Department>(depart2);
            DataCRUD.Create<Department>(depart3);
            DataCRUD.Create<Department>(depart4);
            DataCRUD.Create<Community>(community1);
        }

        [TestMethod]
        public void JoinTest()
        {
            // var person1 = DataCRUD.GetPersonalData("Account1");
            // var person2 = DataCRUD.GetPersonalData("Account2");
            // var person3 = DataCRUD.GetPersonalData("Account3");
            // var depart1 = DataCRUD.GetDepartmentData("管理");
            // var depart2 = DataCRUD.GetDepartmentData("技术");
            // var depart3 = DataCRUD.GetDepartmentData("市场");
            // var community = DataCRUD.GetCommunityData("工会");
            // person1.DepartmentInfo = depart1;
            // person2.DepartmentInfo = depart2;
            // person3.DepartmentInfo = depart3;
            // person1.Communities.Add(community);
            // // person2.Communities.Add(community);
            // // person3.Communities.Add(community);
            // DataCRUD.Update<Person>(person1);
            // DataCRUD.Update<Person>(person2);
            // DataCRUD.Update<Person>(person3);
        }
    }
}
