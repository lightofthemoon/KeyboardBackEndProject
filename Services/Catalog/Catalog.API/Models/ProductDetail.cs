namespace Catalog.API.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Color { get; set; } = default!;
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = default!;

    }
}
