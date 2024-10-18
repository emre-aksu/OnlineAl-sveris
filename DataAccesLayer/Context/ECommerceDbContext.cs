using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Context
{
    public class ECommerceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=Monster;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employees { get; set; }
  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ProductPhoto için composite key tanımı
            //modelBuilder.Entity<ProductPhoto>()
            //            .HasKey(x => new { x.ProductId, x.PhotoPath });

        }




    }
}
