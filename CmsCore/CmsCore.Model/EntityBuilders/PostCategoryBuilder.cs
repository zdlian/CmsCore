using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class PostCategoryBuilder
    {
        public PostCategoryBuilder(EntityTypeBuilder<PostCategory> entityBuilder)
        {
            entityBuilder.HasKey(pc => new { pc.PostId, pc.CategoryId });

            entityBuilder.HasOne(bc => bc.Post)
                .WithMany(b => b.PostCategories)
                .HasForeignKey(bc => bc.PostId);

            entityBuilder.HasOne(bc => bc.Category)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}