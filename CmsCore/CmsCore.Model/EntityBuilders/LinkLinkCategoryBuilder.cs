using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class LinkLinkCategoryBuilder
    {
        public LinkLinkCategoryBuilder(EntityTypeBuilder<LinkLinkCategory> entityBuilder)
        {
            entityBuilder.HasKey(pc => new { pc.LinkId, pc.LinkCategoryId });

            entityBuilder.HasOne(bc => bc.Link)
                .WithMany(b => b.LinkLinkCategories)
                .HasForeignKey(bc => bc.LinkId);

            entityBuilder.HasOne(bc => bc.LinkCategory)
                .WithMany(c => c.LinkLinkCategories)
                .HasForeignKey(bc => bc.LinkCategoryId);
        }
    }
}