﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Common
{
    
        public abstract class BaseEntity
        {     
            public int Id { get; set; }

            public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

            public override string ToString()
            {
                return $"Id={Id}, CreatedAt={CreatedAt}";
            }
        }
    }

