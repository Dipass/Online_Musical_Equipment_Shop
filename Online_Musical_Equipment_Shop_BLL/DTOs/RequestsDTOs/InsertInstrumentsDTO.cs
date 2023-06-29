using Online_Musical_Equipment_Shop_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_BLL.DTOs.RequestsDTOs
{
    public class InsertInstrumentsDTO
    {
        public string InstrumentTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Guid CategoriesId { get; set; }

        public Guid ManufacturerId { get; set; }
    }
}
