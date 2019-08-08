using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// 住址
    /// </summary>
    public class Address : Entity
    {
        public virtual string AddressInfo { get; set; }
        public virtual string PostCode { get; set; }
        public virtual Person PersonInfo { get; set; }
    }
}
