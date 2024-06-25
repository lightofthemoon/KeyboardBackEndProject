using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.API.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("Id")]
        public Guid ProductId { get; set; }
        [Column("ProductName")]
        public string ProductName { get; set; } = default!;
        [Column("Qauntity")]
        public int Quantity { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [Column("Unit")]
        public string Unit {  get; set; } = default!;
        [Column("Desciption")]
        public string Description { get; set; } = default!;
        [Column("DisplayUrl")]
        public string DisplayUrl { get; set; } = default!;
        [Column("CategoryId")]
        public Guid CategoryId { get; set; }
        [Column("BrandId")]
        public Guid BrandId { get; set; }

        public Product(string productName, int quantity, decimal price, string unit, string description, string displayUrl, Guid categoryId, Guid brandId)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Unit = unit;
            Description = description;
            DisplayUrl = displayUrl;
            CategoryId = categoryId;
            BrandId = brandId;
        }
        public Product(Guid Id, string productName) {
            this.ProductId = Id;
            this.ProductName = productName;
        }
    }
}
