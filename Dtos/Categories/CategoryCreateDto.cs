using Api1.Attributes;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Api1.Dtos.Categories
{
    public class CategoryCreateDto
    {
        //[MaxLength(100)]
        public string Name { get; set; } = null!;
        public string Description { get; set; }= null!;
        //[FileTypes("image/jpeg", "image/png")]
        //[FileLength(2)]
        public IFormFile Photo { get; set; }= null!;
    }
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Photo)
                .NotNull()
                .Must(file => file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                .WithMessage("Only JPEG and PNG files are allowed.")
                .Must(file => file.Length <= 2 * 1024 * 1024)
                .WithMessage("File size must be less than or equal to 2MB.");
        }
    }
}
