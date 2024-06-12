using Catalog.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.DTOs
{
    public class CreateProductDTO
    {
        [Required]
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
