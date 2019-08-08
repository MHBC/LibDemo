using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using LibDemo.Domain;

namespace LibDemo.Manager
{
    public static class DataCRUD
    {
        public static void Create<T>(T data)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                using (var Trans = Session.BeginTransaction())
                {
                    try
                    {
                        Session.Save(data);
                        Trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }

        public static Person GetPersonalData(int id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var person = Session.Load<Person>(id);
                    return person;
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }
        public static Person GetPersonalData(string account)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var person = Session.Query<Person>().First(p => p.Account == account);
                    return person;
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }
    
        public static Department GetDepartmentData(int id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var department = Session.Load<Department>(id);
                    return department;
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }
        public static Department GetDepartmentData(string name)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var department = Session.Query<Department>().First(d => d.DepartmentName == name);
                    return department;
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }

        public static Community GetCommunityData(int id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var community = Session.Load<Community>(id);
                    return community;
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }
        public static Community GetCommunityData(string name)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var community = Session.Query<Community>().First(c => c.CommunityName == name);
                    return community;
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }

        public static List<Person> ListDepartmentMembers(int id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    Department department = Session.Load<Department>(id);
                    return department.Persons.ToList();
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }

        public static List<Person> ListCommunityMembers(int id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    Community community = Session.Load<Community>(id);
                    return community.Persons.ToList();
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }

        public static void Update<T>(T data)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                using (var Trans = Session.BeginTransaction())
                {
                    try
                    {
                        Session.Update(data);
                        Trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }

        public static void DeletePerson(object id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                using (var Trans = Session.BeginTransaction())
                {
                    try
                    {
                        var data = Session.Get<Person>(id);
                        Trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }
    }
}