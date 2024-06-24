namespace Catalog.API.DTOs
{
    public class UpdateProductDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string DisplayUrl { get; set; } = default!;
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
    }
}
