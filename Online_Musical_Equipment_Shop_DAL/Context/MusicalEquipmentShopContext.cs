using Microsoft.EntityFrameworkCore;
using Online_Musical_Equipment_Shop_DAL.Entities;
using Online_Musical_Equipment_Shop_DAL.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Context
{
    public class MusicalEquipmentShopContext : DbContext
    {
        public MusicalEquipmentShopContext(DbContextOptions<MusicalEquipmentShopContext> options) 
            : base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Countries> Countries { get; set; } 
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Instruments> Instruments { get; set; }
        public DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            Seeding seeding = new Seeding();

            modelBuilder.Entity<Categories>().HasData(seeding.Categories);
            modelBuilder.Entity<Countries>().HasData(seeding.Countries);
            modelBuilder.Entity<Manufacturer>().HasData(seeding.Manufacturer);
            modelBuilder.Entity<Instruments>().HasData(seeding.Instruments);
            modelBuilder.Entity<Items>().HasData(seeding.Items);
        }
    }
}
