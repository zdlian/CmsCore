using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CmsCore.Model.EntityBuilders
{
    public class PageBuilder
    {
        public PageBuilder(EntityTypeBuilder<Page> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entityBuilder.Property(e => e.Slug).IsRequired().HasMaxLength(200);
            entityBuilder.Property(e => e.IsPublished).IsRequired();
            entityBuilder.Property(e => e.SeoTitle).HasMaxLength(200);
            entityBuilder.HasOne(e => e.Template).WithMany(t => t.Pages).HasForeignKey(p => p.TemplateId);
        }
    }
}
