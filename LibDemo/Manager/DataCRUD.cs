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
        /// <summary>
        /// 数据库创建新数据的泛型方法
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
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

        /// <summary>
        /// 通过ID读取个人信息的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 通过账号读取个人信息的方法，为ID方法的重载
        /// 读取个人信息后校验密码
        /// 后可考虑将账号信息另开一表存储
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
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
    
        /// <summary>
        /// 通过部门ID获取部门类的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 通过部门名获取部门类的方法，为ID方法的重载
        /// 大概没什么用
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 通过社团ID获取社团信息的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 通过社团名获取社团信息的方法，为ID方法的重载
        /// 同样应该没什么用
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取Key为某ID的部门员工列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Person> ListDepartmentMembers(int id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var department = GetDepartmentData(id);
                    return department.Persons.ToList();
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }

        /// <summary>
        /// 获取Key为某ID的社团成员列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Person> ListCommunityMembers(int id)
        {
            using (var Session = NHibernateHelper.GetSession())
            {
                try
                {
                    var community = GetCommunityData(id);
                    return community.Persons.ToList();
                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }

        /// <summary>
        /// 数据库更新数据的泛型方法
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
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

        /// <summary>
        /// 数据库删除个人数据的方法，参数为ID
        /// 用户登陆后将读取ID，删除账号时调用此方法即可
        /// </summary>
        /// <param name="id"></param>
        public static void DeletePerson(int id)
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