using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WashingCarDBJosue.DAL.Entities;

namespace WashingCarDBJosue.DAL
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetails> VehiclesDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex("Id", "ServiceId").IsUnique();
            modelBuilder.Entity<VehicleDetails>().HasIndex("Id", "VehiculeId").IsUnique(); // índices compuestos
        }


    }
}
