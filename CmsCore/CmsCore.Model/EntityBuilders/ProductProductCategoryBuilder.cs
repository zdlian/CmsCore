using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class ProductProductCategoryBuilder
    {
        public ProductProductCategoryBuilder(EntityTypeBuilder<ProductProductCategory> entityBuilder)
        {
            entityBuilder.HasKey(pc => new { pc.ProductId, pc.ProductCategoryId });

            entityBuilder.HasOne(bc => bc.Product)
                .WithMany(b => b.ProductProductCategories)
                .HasForeignKey(bc => bc.ProductId).OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            entityBuilder.HasOne(bc => bc.ProductCategory)
                .WithMany(c => c.ProductProductCategories)
                .HasForeignKey(bc => bc.ProductCategoryId).OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
        }
    }
}