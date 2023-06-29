using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Musical_Equipment_Shop_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Context.Configurations
{
    public class InstrumentsConfigurations : IEntityTypeConfiguration<Instruments>
    {
        public void Configure(EntityTypeBuilder<Instruments> builder)
        {
            builder
                .HasMany(x => x.Items)
                .WithOne(x => x.Instruments)
                .HasForeignKey(x => x.InstrumentsId);
        }
    }
}
