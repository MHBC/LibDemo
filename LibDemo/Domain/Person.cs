using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    public class Person: Entity
    {
        public virtual string Name { get; set; }
        public virtual string Job { get; set; }
        /// <summary>
        /// M for male, F for female
        /// </summary>
        public virtual char Sex { get; set; }
    }
}
