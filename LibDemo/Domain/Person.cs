using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// 个人信息，账号、密码、姓、名均为非空
    /// </summary>
    public class Person : Entity
    {
        public virtual string Account { get; set; }
        public virtual string Password { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string JobTitle { get; set; }

        // Connection to other tables
        public virtual Address ResidentialAddress { get; set; }
        public virtual Department DepartmentInfo { get; set; }
        public virtual ICollection<Community> Communities { get; set; }
    }

    /// <summary>
    /// 管理员为个人的子类，并有另外的管理员账号密码
    /// </summary>
    public class Admin : Person
    {
        public virtual string AdminAccount { get; set; }
        public virtual string AdminPassword { get; set; }
    }
}
