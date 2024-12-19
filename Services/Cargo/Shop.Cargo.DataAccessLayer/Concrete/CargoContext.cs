using Microsoft.EntityFrameworkCore;

namespace Shop.Cargo.DataAccessLayer.Concrete;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1434;Initial Catalog=MultiShopOrderDb;User=sa;Password=123456aA*;TrustServerCertificate=True;");
    }
    
    
    
}