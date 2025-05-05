using Microsoft.EntityFrameworkCore;
using Practical1.Models;

namespace Practical1.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
