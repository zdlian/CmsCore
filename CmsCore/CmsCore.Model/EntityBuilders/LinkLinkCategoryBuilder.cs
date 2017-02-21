using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class PostPostCategoryBuilder
    {
        public PostPostCategoryBuilder(EntityTypeBuilder<PostPostCategory> entityBuilder)
        {
            entityBuilder.HasKey(pc => new { pc.PostId, pc.PostCategoryId });

            entityBuilder.HasOne(bc => bc.Post)
                .WithMany(b => b.PostPostCategories)
                .HasForeignKey(bc => bc.PostId);

            entityBuilder.HasOne(bc => bc.PostCategory)
                .WithMany(c => c.PostPostCategories)
                .HasForeignKey(bc => bc.PostCategoryId);
        }
    }
}