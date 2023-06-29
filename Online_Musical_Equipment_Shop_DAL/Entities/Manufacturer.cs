using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public Countries Countries { get; set; } = null!;

        public Guid CountriesId { get; set; }

        public ICollection<Instruments> Instruments { get; set; } = null!;
    }
}
