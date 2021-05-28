using Microsoft.EntityFrameworkCore;

namespace apiVaiVoa.Models
{
  public class CartaoVirtualContext : DbContext
  {
    public CartaoVirtualContext(DbContextOptions<CartaoVirtualContext> options) : base(options)
    {
    }

    public DbSet<CartaoVirtual> CarataoVirtual { get; set; }
  }
}