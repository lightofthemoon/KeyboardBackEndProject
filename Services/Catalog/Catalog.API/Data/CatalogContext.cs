using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                connectionString: "Server=localhost;Port=5432;Database=CatalogServiceDB;User Id=postgres;Password=postgres");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e => e.ToTable("Products"));
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                                    .HasColumnName("Id");
                entity.Property(e => e.ProductName).HasColumnName("ProductName");
                entity.Property(e => e.Quantity).IsRequired().HasColumnName("Quantity");
                entity.Property(e => e.Price).IsRequired().HasColumnName("Price");
                entity.Property(e => e.Unit).IsRequired().HasColumnName("Unit");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.DisplayUrl).HasColumnName("DisplayUrl");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryId");
                entity.Property(e => e.BrandId).HasColumnName("BrandId");
            });

            modelBuilder.Entity<Brand>(e => e.ToTable("Brands"));
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId)
                                    .HasColumnName("Id");
                entity.Property(e => e.BrandName).HasColumnName("BrandName");
                entity.Property(e => e.PhoneNumber).IsRequired().HasColumnName("PhoneNumber");
                entity.Property(e => e.Email).IsRequired().HasColumnName("Email");
            });

            modelBuilder.Entity<Category>(e => e.ToTable("Categories"));
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                                    .HasColumnName("Id");
                entity.Property(e => e.CategoryName).HasColumnName("CategoryName");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.Property(e => e.Id)
                                    .HasColumnName("Id");
                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.Color).IsRequired().HasColumnName("Color");
                entity.Property(e => e.Price).IsRequired().HasColumnName("Price");
                entity.Property(e => e.Quantity).IsRequired().HasColumnName("Quantity");
                entity.Property(e => e.ImageUrl).HasColumnName("ImageUrl");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
