using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// 部门，含有一个员工名录
    /// </summary>
    public class Department : Entity
    {
        public virtual string DepartmentName { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
