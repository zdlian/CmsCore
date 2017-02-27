using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class LinkBuilder
    {

        public LinkBuilder(EntityTypeBuilder<Link> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entityBuilder.Property(p => p.Url).IsRequired().HasMaxLength(200);
            entityBuilder.HasOne(p => p.Language).WithMany(l => l.Links).HasForeignKey(p => p.LanguageId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
