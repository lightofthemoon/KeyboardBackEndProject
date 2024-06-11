using System.ComponentModel.DataAnnotations;

namespace Catalog.API.DTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        public string CategoryName { get; set; } = default!;
    }
}
