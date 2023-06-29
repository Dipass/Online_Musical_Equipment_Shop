using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Musical_Equipment_Shop_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Context.Configurations
{
    public class ManufacturerConfigurations : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder
                .HasMany(x => x.Instruments)
                .WithOne(x => x.Manufacturer)
                .HasForeignKey(x => x.ManufacturerId);
        }
    }
}
