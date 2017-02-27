using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class ProductBuilder
    {

        public ProductBuilder(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Title).HasMaxLength(200).IsRequired();
            entityBuilder.Property(p => p.Slug).HasMaxLength(200).IsRequired();
            entityBuilder.Property(p => p.SeoTitle).HasMaxLength(200);
            entityBuilder.HasOne(e => e.ParentProduct).WithMany(p => p.ChildProducts).HasForeignKey(p => p.ParentProductId).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(p => p.Language).WithMany(l => l.Products).HasForeignKey(p => p.LanguageId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
