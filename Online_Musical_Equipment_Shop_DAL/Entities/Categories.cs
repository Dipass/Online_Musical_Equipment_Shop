using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Entities
{
    public class Categories : BaseEntity
    {
        public string CategoryTitle { get; set; } = string.Empty;    

        public ICollection<Instruments> Instruments { get; set; } = null!;
    }
}
