using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity() => Id = Guid.NewGuid();
    }
}
