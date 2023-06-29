using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Entities
{
    public class Instruments : BaseEntity   
    {
        public string InstrumentTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty; 

        public Categories Categories { get; set; } = null!;

        public Guid CategoriesId { get; set; }

        public Manufacturer Manufacturer { get; set; } = null!;

        public Guid ManufacturerId { get; set; } 

        public ICollection<Items> Items { get; set; } = null!;
    }
}
