using Api1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api1.Data.Configurations
{
    public class CategoryConfigurations:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //fluent api configuration for Category entity
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedDate).IsRequired().HasComputedColumnSql("GETDATE()");
            builder.Property(c => c.UpdatedDate);
        }
    }
}
