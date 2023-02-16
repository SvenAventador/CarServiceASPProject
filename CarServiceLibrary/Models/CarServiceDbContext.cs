using Microsoft.EntityFrameworkCore;
using CarServiceLibrary.Models.Entities;

#pragma warning disable CS8618

namespace CarServiceLibrary.Models;

public class CarServiceDbContext : DbContext
{
    public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();

        modelBuilder.Entity<Cars>().Property(m => m.Id).UseIdentityColumn();
        modelBuilder.Entity<Category>().Property(m => m.Id).UseIdentityColumn();
        modelBuilder.Entity<Orders>().Property(s => s.Id).UseIdentityColumn();
        modelBuilder.Entity<Services>().Property(p => p.Id).UseIdentityColumn();
        modelBuilder.Entity<Statuses>().Property(p => p.Id).UseIdentityColumn();
        modelBuilder.Entity<Types>().Property(p => p.Id).UseIdentityColumn();
        modelBuilder.Entity<Users>().Property(p => p.Id).UseIdentityColumn();
    }

    public DbSet<Cars> Cars { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Services> Services { get; set; }
    public DbSet<Statuses> Statuses { get; set; }
    public DbSet<Types> Types { get; set; }
    public DbSet<Users> Users { get; set; }
}