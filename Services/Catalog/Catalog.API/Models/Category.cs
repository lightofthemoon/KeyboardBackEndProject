namespace Catalog.API.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = default!;

        public Category(string categoryName)
        {
            this.CategoryName = categoryName;
        }
    }
}
