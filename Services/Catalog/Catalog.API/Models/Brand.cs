using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Models
{
    public class Brand
    {
        [Key]
        public Guid BrandId { get; set; }
        public string BrandName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;

        public Brand(Guid Id, string BrandName)
        {
            this.BrandId = Id;
            this.BrandName = BrandName;
        }
        public Brand()
        {
            
        }
    }
}
