using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Common
{
    
        public abstract class BaseEntity
        {     
            public Guid Id { get; set; }

            public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

            public DateTime GetCreatedAt()
            {
                return CreatedAt;
            }

            public override string ToString()
            {
                    return $"Id={Id}, CreatedAt={CreatedAt}";
            }
        }
    }

