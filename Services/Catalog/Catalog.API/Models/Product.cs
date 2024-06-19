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
        public Guid CategoryId { get; set; }
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
