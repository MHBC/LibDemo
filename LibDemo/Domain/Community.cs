using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// Community
    /// </summary>
    public class Community : Entity
    {
        public virtual string CommunityName { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
