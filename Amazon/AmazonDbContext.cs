using Amazon.Models;
using Microsoft.EntityFrameworkCore;
namespace Amazon
{
    public class AmazonDbContext : DbContext
    {


        public AmazonDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Users> users { get; set; }
    }
}
