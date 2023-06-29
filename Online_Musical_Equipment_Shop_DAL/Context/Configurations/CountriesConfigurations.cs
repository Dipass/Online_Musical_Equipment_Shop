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
    public class CountriesConfigurations : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {
            builder
                .HasMany(x => x.Manufacturers)
                .WithOne(x => x.Countries)
                .HasForeignKey(x => x.CountriesId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasMany(x => x.Items)
                .WithOne(x => x.Countries)
                .HasForeignKey(x => x.CountriesId);

            builder
                .HasIndex(x => x.CountriesTitle)
                .IsUnique(true);
        }
    }
}
