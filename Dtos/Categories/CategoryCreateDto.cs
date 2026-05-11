using Api1.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api1.Dtos.Categories
{
    public class CategoryCreateDto
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string Description { get; set; }= null!;
        //[FileTypes("image/jpeg", "image/png")]
        //[FileLength(2)]
        public IFormFile Photo { get; set; }= null!;
    }
}
