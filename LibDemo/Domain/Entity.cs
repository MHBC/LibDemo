using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// 基类，定义ID
    /// </summary>
    public abstract class Entity
    {
        public virtual int Id { get; set; }
    }
}
