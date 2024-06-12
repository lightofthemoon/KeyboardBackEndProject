using System.ComponentModel.DataAnnotations;

namespace Catalog.API.DTOs
{
    public class CreateBrandDTO
    {
        [Required]
        public string BrandName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
