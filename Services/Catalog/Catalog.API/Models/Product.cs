namespace Catalog.API.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Unit {  get; set; } = default!;
        public string Description { get; set; } = default!;
        public string DisplayUrl { get; set; } = default!;
        public List<Category> Category { get; set; } = new();
        public List<Brand> Brands { get; set; } = new();
    }
}
