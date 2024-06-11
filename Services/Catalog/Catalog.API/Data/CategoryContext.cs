using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
            connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=CatalogProductDB;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e => e.ToTable("Category"));
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                                    .HasColumnName("Id")
                                    .HasDefaultValueSql("nextval('account.item_id_seq'::regclass)");
                entity.Property(e => e.CategoryName).IsRequired().HasColumnName("CategoryName");
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Category { get; set; }


    }
}
