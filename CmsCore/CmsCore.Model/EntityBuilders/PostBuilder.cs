using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class PostBuilder
    {

        public PostBuilder(EntityTypeBuilder<Post> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            entityBuilder.Property(p => p.Slug).IsRequired().HasMaxLength(200);
            entityBuilder.Property(p => p.Body).IsRequired().HasMaxLength(250);
            entityBuilder.Property(p => p.SeoTitle).HasMaxLength(200);
            entityBuilder.Property(p => p.SeoDescription);
            entityBuilder.Property(p => p.SeoKeywords);
            entityBuilder.Property(p => p.IsPublished).IsRequired();

            
        }

    }
}
