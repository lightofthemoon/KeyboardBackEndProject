using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.API.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Column("Id")]
        public Guid CategoryId { get; set; }
        [Column("CategoryName")]
        public string CategoryName { get; set; } = default!;

        public Category(string categoryName)
        {
            this.CategoryName = categoryName;
        }

        public Category(Guid id, string CategoryName)
        {
            this.CategoryId = id;
            this.CategoryName = CategoryName;
        }
    }
}
