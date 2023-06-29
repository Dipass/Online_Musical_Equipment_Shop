using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Musical_Equipment_Shop_DAL.Entities;
using Online_Musical_Equipment_Shop_DAL.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Context.Configurations
{
    public class CategoriesConfigurations : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder
                .HasIndex(x => x.CategoryTitle)
                .IsUnique(true);

            builder
                .HasMany(x => x.Instruments)
                .WithOne(x => x.Categories)
                .HasForeignKey(x => x.CategoriesId);
        }
    }
}
