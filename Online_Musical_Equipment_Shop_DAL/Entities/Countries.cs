using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Entities
{
    public class Countries : BaseEntity
    {
        public string CountriesTitle { get; set; } = string.Empty;

        public ICollection<Manufacturer> Manufacturers { get; set; } = null!;

        public ICollection<Items> Items { get; set; } = null!;
    }
}
