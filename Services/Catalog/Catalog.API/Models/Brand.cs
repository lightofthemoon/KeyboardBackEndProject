using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.API.Models
{
    [Table("Brands")]

    public class Brand
    {
        [Key]
        [Column("Id")]
        public Guid BrandId { get; set; }
        [Column("BrandName")]
        public string BrandName { get; set; } = default!;
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; } = default!;
        [Column("Email")]
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
