

using ConsoleAppDataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppDataBase.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    public DbSet<AddressEntity> Adresses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ManufactureEntity> Manufactures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)");
    }
}
