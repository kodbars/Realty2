using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realty_Models;

namespace Realty_Db.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<House> Houses { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Newbuilding> Newbuildings { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                new Region() { Id = 1, Nm = "Москва", GIBDD = "77" },
                new Region() { Id = 2, Nm = "Московсая область", GIBDD = "50" },
                new Region() { Id = 3, Nm = "Санкт_Петербург", GIBDD = "78" }
                );
            modelBuilder.Entity<Region>(entity => 
            {
                entity.HasIndex(e => e.GIBDD).IsUnique();
            });
            modelBuilder.Entity<House>(entity => 
            {
                entity.HasIndex(e => e.Lot).IsUnique();
            });
            modelBuilder.Entity<Owner>(entity => 
            {
                entity.HasIndex(e => e.NumTitul).IsUnique();
            });

        }
    }
}
