﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDemo.Domain
{
    /// <summary>
    /// Basic Class with ID defined
    /// </summary>
    public abstract class Entity
    {
        public virtual int Id { get; set; }
    }
}
