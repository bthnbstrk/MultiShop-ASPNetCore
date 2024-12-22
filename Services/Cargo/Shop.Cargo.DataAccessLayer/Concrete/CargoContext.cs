using Microsoft.EntityFrameworkCore;
using Shop.Cargo.EntityLayer.Concrete;

namespace Shop.Cargo.DataAccessLayer.Concrete;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1441;Initial Catalog=MultiShopCargoDb;User=sa;Password=123456aA*;TrustServerCertificate=True;");
    }
    
    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }
    
}