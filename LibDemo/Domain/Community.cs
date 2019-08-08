using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// 社团，含有一个成员名录
    /// </summary>
    public class Community : Entity
    {
        public virtual string CommunityName { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
