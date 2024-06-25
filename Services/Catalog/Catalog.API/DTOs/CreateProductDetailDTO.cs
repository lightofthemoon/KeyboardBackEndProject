using System.ComponentModel.DataAnnotations;

namespace Catalog.API.DTOs
{
    public class CreateProductDetailDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public string Color { get; set; } = default!;
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string ImageUrl { get; set; } = default!;
    }
}
