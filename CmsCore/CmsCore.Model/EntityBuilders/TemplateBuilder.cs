using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class TemplateBuilder
    {
        public TemplateBuilder(EntityTypeBuilder<Template> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entityBuilder.Property(e => e.ViewName).IsRequired().HasMaxLength(200);
            entityBuilder.HasMany(p => p.Pages).WithOne(e => e.Template).HasForeignKey(p => p.TemplateId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
