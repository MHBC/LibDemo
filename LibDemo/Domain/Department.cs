using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// Department
    /// </summary>
    public class Department : Entity
    {
        public virtual string DepartmentName { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
