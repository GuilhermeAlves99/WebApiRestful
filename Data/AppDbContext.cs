using Microsoft.EntityFrameworkCore;
using WebApiRestful.Model;

namespace WebApiRestful.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
        {
        }
        public DbSet<Product> Products => Set<Product>();
    }
}
