using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Entities
{
    public class Items : BaseEntity
    {
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; } 

        public DateTime CreatedDateTime { get; set; }

        public Instruments Instruments { get; set; } = null!;

        public Guid InstrumentsId { get; set; }

        public Countries Countries { get; set; } = null!;

        public Guid CountriesId { get; set; }
    }
}
