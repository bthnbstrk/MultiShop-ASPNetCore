using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1434;Initial Catalog=MultiShopOrderDb;User=sa;Password=123456aA*;TrustServerCertificate=True;");
    }
    
    public DbSet<Address> Addresses { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    public DbSet<Ordering> Orderings { get; set; }
}