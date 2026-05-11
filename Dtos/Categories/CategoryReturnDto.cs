using Api1.Models;

namespace Api1.Dtos.Categories
{
    public class CategoryReturnDto
    {
        public string Name { get; set; }= null!;
        public string Description { get; set; }= null!;
        public string ImageUrl { get; set; }
        public List<ProductInCategoryReturnDto>? Products { get; set; }
    }
    public class ProductInCategoryReturnDto
    {
        public string Name { get; set; }= null!;
        public string Description { get; set; }= null!;
    }
}
