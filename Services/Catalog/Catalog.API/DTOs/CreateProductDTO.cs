using Catalog.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        public string ProductName { get; set; } = default!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Unit { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!;
        [Required]
        public string DisplayUrl { get; set; } = default!;
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid BrandId { get; set; }
    }
}
